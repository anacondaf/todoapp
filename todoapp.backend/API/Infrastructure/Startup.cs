﻿using Application;
using Asp.Versioning;
using Infrastructure.Commons;
using Infrastructure.Identity;
using Infrastructure.Persistences;
using Infrastructure.Persistences.Initialization;
using Infrastructure.ServiceBus;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Sidecar.KeyVault;

namespace Infrastructure;

public static class Startup
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services
            .AddServices()
            .AddPersistence(configuration)
            .AddApiVersioning()
            .AddScoped<ICustomSeederRunner, CustomSeederRunner>()
            .AddServices(typeof(ICustomSeeder), ServiceLifetime.Transient)
            .AddTransient<ApplicationDbSeeder>()
            .AddTransient<ApplicationDbInitializer>()
            .AddServiceBus()
            .AddSideCarService(configuration)
            .Authorization();

        return services;
    }

    public static async Task InitializeDatabasesAsync(this IServiceProvider services, CancellationToken cancellationToken)
    {
        using var scope = services.CreateScope();

        await scope.ServiceProvider.GetRequiredService<ApplicationDbInitializer>().InitializeAsync(cancellationToken);
    }

    public static async Task InitializeServiceBus(this IServiceProvider serviceProvider)
    {
        using var scope = serviceProvider.CreateScope();
        await scope.ServiceProvider.GetRequiredService<IServiceBusClient>().Initialize();
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

    public static IServiceCollection AddSideCarService(this IServiceCollection services, IConfiguration configuration)
    {
        return services.UseKVConfiguration(configuration);
    }

    public static IServiceCollection Authorization(this IServiceCollection services)
    {
        Authentication(services);

        return services
            .AddAuthorization()
            .AddIdentityApiEndpoints<ApplicationUser>()
            .Services;
    }

    private static void Authentication(IServiceCollection services)
    {
        services
            .AddIdentityCore<ApplicationUser>()
            .AddDefaultUI()
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultTokenProviders();
    }
}
