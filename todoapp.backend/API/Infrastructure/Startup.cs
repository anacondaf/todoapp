using Asp.Versioning;
using Infrastructure.Commons;
using Infrastructure.Persistences;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class Startup
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services
            .AddServices()
            .AddPersistence(configuration)
            .AddApiVersioning()
            .AddScoped<ICustomSeedRunner, CustomSeedRunner>();

        return services;
    }

    private static IServiceCollection AddApiVersioning(this IServiceCollection services)
    {
        services
            .AddApiVersioning(options =>
             {
                 options.DefaultApiVersion = new ApiVersion(1, 0);
                 options.AssumeDefaultVersionWhenUnspecified = true;
                 options.ReportApiVersions = true;
             })
            .AddApiExplorer(options =>
            {
                options.GroupNameFormat = "'v'VVV";
                options.SubstituteApiVersionInUrl = true;
            });

        return services;
    }

    public static IEndpointRouteBuilder MapEndpoints(this IEndpointRouteBuilder builder)
    {
        builder.MapControllers();
        return builder;
    }
}
