namespace Application;

using MediatR;
using Microsoft.Extensions.DependencyInjection;

public static class Startup
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services
            .AddMediatR(configuration => configuration.RegisterServicesFromAssembly(typeof(Startup).Assembly))
            .AddScoped(typeof(IPipelineBehavior<,>), typeof(LoggingBehaviour<,>));

        return services;
    }
}
