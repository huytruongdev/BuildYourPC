using Microsoft.Extensions.Configuration;

namespace BuildYourPC.Shared;

public static class BaseConfiguration
{
    private static readonly IConfiguration _appSettings = new ConfigurationBuilder()
        .AddJsonFile(Path.Combine(AppContext.BaseDirectory, "baseconfiguration.json"), true)
        .AddJsonFile(Path.Combine(AppContext.BaseDirectory, "baseconfiguration.local.json"), true)
        .AddJsonFile(Path.Combine(AppContext.BaseDirectory, "appsettings.json"), true)
        .AddJsonFile(Path.Combine(AppContext.BaseDirectory, "appsettings.local.json"), true)
        .Build();

    public static IConfiguration GetConfiguration() => _appSettings;
}
