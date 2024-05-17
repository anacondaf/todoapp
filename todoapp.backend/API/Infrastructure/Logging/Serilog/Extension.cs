using Microsoft.AspNetCore.Builder;
using Serilog;
using Serilog.Sinks.SystemConsole.Themes;

namespace Infrastructure;

public static class Extension
{
    public static void RegisterSerilog(this WebApplicationBuilder builder)
    {
        _ = builder.Host.UseSerilog((context, configuration) =>
        {
            ConfigureEnrichers(configuration);
            ConfigureConsoleLogging(configuration);
        });
    }

    private static void ConfigureEnrichers(LoggerConfiguration serilogConfig)
    {
        serilogConfig
            .Enrich.FromLogContext()
            .Enrich.WithAssemblyName()
            .Enrich.WithAssemblyVersion()
            .Enrich.WithEnvironmentName()
            .Enrich.WithThreadId()
            .Enrich.WithMachineName()
            .Enrich.WithMemoryUsage()
            .Enrich.WithNsbExceptionDetails();
    }

    private static void ConfigureConsoleLogging(LoggerConfiguration serilogConfig)
    {
        serilogConfig.WriteTo.Async(wt => wt.Console(outputTemplate: "[{Timestamp:HH:mm:ss} {Level:u3}] {Message:lj}{NewLine}{Exception}", theme: AnsiConsoleTheme.Sixteen));
    }

    private static void ConfigureWriteToFile(LoggerConfiguration serilogConfig, bool writeToFile)
    {
        if (writeToFile)
        {
            serilogConfig.WriteTo.File(
                "../Host/Logs/logs.json",
                restrictedToMinimumLevel: Serilog.Events.LogEventLevel.Information,
                rollingInterval: RollingInterval.Day,
                retainedFileCountLimit: 5);
        }
    }
}
