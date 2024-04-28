using Microsoft.Extensions.DependencyInjection;

namespace Application;
public static class Startup
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services
            .AddMediatR(configuration => configuration.RegisterServicesFromAssembly(typeof(Startup).Assembly));

        return services;
    }
}
