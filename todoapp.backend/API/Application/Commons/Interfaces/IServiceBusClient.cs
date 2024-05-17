using NServiceBus;

namespace Application;

public interface IServiceBusClient
{
    Task Initialize();
    Task SendCommandAsync<T>(T cmd) where T : ICommand;
    Task PublishEventAsync<T>(T evt) where T : IEvent;
}