using BuildYourPC.Application.Interfaces;
using BuildYourPC.Application.Services;
using BuildYourPC.Infrastructure.DB;
using Microsoft.EntityFrameworkCore;

namespace BuildYourPC.API;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddScoped<IComponentService, ComponentService>();

        builder.Services.AddControllers();
        // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
        builder.Services.AddOpenApi();

        //builder.Services.AddDbContext<ApplicationDbContext>(options =>
        //{
        //    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
        //    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        //    MySqlProvider.Initialize(connectionString!);
        //});
        var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")!;
        MySqlProvider.Initialize(connectionString);

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.MapOpenApi();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();


        app.MapControllers();

        app.Run();
    }
}
