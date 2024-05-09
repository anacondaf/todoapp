using Application.Commons.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Commons;

public static class Startup
{
    public static IServiceCollection AddServices(this IServiceCollection services) =>
        services
            .AddServices(typeof(ITransientService), ServiceLifetime.Transient)
            .AddServices(typeof(IScopedService), ServiceLifetime.Scoped);

    /// <summary>
    /// Register services to DI Container, using marker interface ITransientService, IScopedService
    /// </summary>
    /// <param name="services"></param>
    /// 
    /// <returns>IServiceCollection</returns>
    internal static IServiceCollection AddServices(this IServiceCollection services, Type interfaceType, ServiceLifetime serviceLifetime)
    {
        var types =
            AppDomain.CurrentDomain.GetAssemblies()
            .SelectMany(a => a.GetTypes())
            .Where(t => t.IsClass && interfaceType.IsAssignableFrom(t))
            .Select(t => new
            {
                Service = t.GetInterfaces().FirstOrDefault(),
                Implementation = t,
            })
            .Where(t => interfaceType.IsAssignableFrom(t.Service))
            .ToList();

        foreach (var type in types)
        {
            services.AddService(type.Service!, type.Implementation, serviceLifetime);
        }

        return services;
    }

    internal static IServiceCollection AddService(this IServiceCollection services, Type serviceType, Type implementationType, ServiceLifetime serviceLifetime)
        => serviceLifetime switch
        {
            ServiceLifetime.Transient => services.AddTransient(serviceType, implementationType),
            ServiceLifetime.Scoped => services.AddScoped(serviceType, implementationType),
            ServiceLifetime.Singleton => services.AddSingleton(serviceType, implementationType),
            _ => throw new ArgumentException("Invalid lifeTime", nameof(serviceLifetime))
        };
}
