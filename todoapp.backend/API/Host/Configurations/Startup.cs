using Microsoft.Extensions.Configuration;

namespace Host.Configurations;

public static class Startup
{
    public static IConfiguration AddConfigurations(this IConfigurationBuilder configuration)
    {
        const string ConfigurationDirectory = "Configurations";

        return configuration
            .AddJsonFile($"{ConfigurationDirectory}/database.json", optional: false, reloadOnChange: true)
            .AddEnvironmentVariables()
            .Build();
    }
}