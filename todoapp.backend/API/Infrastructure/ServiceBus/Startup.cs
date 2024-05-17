using Application;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.ServiceBus;

public static class Startup
{
    public static IServiceCollection AddServiceBus(this IServiceCollection services)
    {
#if NServiceBus
        services.AddSingleton<IServiceBusClient, ParticularServiceBusClient>();
#endif

        return services;
    }
}
