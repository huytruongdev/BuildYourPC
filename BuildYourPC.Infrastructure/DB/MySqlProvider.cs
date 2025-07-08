using System.Data;
using System.Data.Common;
using System.Diagnostics;
using Dapper;
using Domain.Interfaces;
using MySqlConnector;

namespace BuildYourPC.Infrastructure.DB;

public class MySqlProvider
{
    private static readonly Lazy<MySqlProvider> _lazy = new(() => new());
    public static MySqlProvider MySqlInstance => _lazy.Value;
    private static string? _connectionString;

    private MySqlProvider()
    {
    }

    private DbConnection CreateConnection => new MySqlConnection(_connectionString);

    public static void Initialize(string connectionString)
    {
        if (string.IsNullOrWhiteSpace(connectionString))
        {
            throw new ArgumentException("Connection string cannot be null or empty.", nameof(connectionString));
        }
        _connectionString = connectionString;
    }

    private async Task<T> Execute<T>(string sql, Func<DbConnection, Task<T>> func)
    {
        Stopwatch stopWatch = Stopwatch.StartNew();
        T result = default;
        try
        {
            if (sql.Contains(' '))
            {
                sql = sql.ToUpper();
                int index = sql.IndexOf(" WHERE ");
                if (index > 0)
                    sql = sql[..index];
                index = sql.IndexOf(" VALUES ");
                if (index > 0)
                    sql = sql[..index];
                index = sql.IndexOf(" SET ");
                if (index > 0)
                    sql = sql[..index];
            }
            using DbConnection connection = CreateConnection;
            await connection.OpenAsync();
            result = await func(connection);
        }
        catch (Exception ex)
        {
            stopWatch.Stop();
            //throw new InvalidOperationException($"{lmid}: SQL Error after: {stopWatch.Elapsed}. SQL/SP: {sql}", ex);
        }
        finally
        {
            stopWatch.Stop();
            if (stopWatch.Elapsed > TimeSpan.FromSeconds(30))
            {
                //_logger.LogInformation($"{lmid}: Execute db exceed limit time: {stopWatch.Elapsed}. SQL/SP: {sql}");
            }
        }
        return result;
    }

    public async Task<int> ExecuteAsync<T>(string sql, T entity, object? parameters = null) where T : IAuditableEntity
    {
        entity.CreatedAt = DateTime.Now;
        entity.UpdatedAt = DateTime.Now;
        return await Execute(sql, async (connection) =>
        {
            return await connection.ExecuteAsync(sql, parameters);
        });
    }

    public async Task<IEnumerable<T>> QueryAsync<T>(string sql, object param = null, int? commandTimeout = null, IDbTransaction transaction = null)
        => await Execute(sql, async (connection) => await connection.QueryAsync<T>(sql, param, transaction, commandTimeout, sql.Contains(' ') ? CommandType.Text : CommandType.StoredProcedure));
}
