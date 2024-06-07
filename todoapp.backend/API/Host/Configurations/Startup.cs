using System.Reflection;

namespace Host.Configurations;

public static class Startup
{
    public static WebApplicationBuilder AddConfigurations(this WebApplicationBuilder builder)
    {
        const string ConfigurationDirectory = "Configurations";

        builder
            .Configuration
            .AddJsonFile($"{ConfigurationDirectory}/database.json", optional: false, reloadOnChange: true)
            // .AddJsonFile($"{ConfigurationDirectory}/logging.json", optional: false, reloadOnChange: true)
            // .AddJsonFile($"appsettings.json", optional: false, reloadOnChange: true)
            .AddJsonFile($"{ConfigurationDirectory}/nservicebus.json", optional: false, reloadOnChange: true)
            .AddJsonFile($"{ConfigurationDirectory}/azurekv.json", optional: false, reloadOnChange: true)
            .AddUserSecrets(Assembly.GetExecutingAssembly(), true)
            .AddEnvironmentVariables()
            .Build();

        return builder;
    }
}