using BuildYourPC.Shared;

namespace BuildYourPC.API;

public static class Configuration
{
    private static readonly IConfiguration _appSettings = BaseConfiguration.GetConfiguration();

    public static readonly string Test = _appSettings["Test"]!;
}
