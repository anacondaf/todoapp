using NServiceBus;
using Microsoft.Extensions.Configuration;
using Application;


namespace Infrastructure;

public class ParticularServiceBusClient(IConfiguration configuration) : IServiceBusClient, IDisposable, IAsyncDisposable
{
    private IEndpointInstance _instance;
    private IConfiguration _configuration = configuration;

    async Task IServiceBusClient.Initialize()
    {
        var settings = _configuration.GetSection(nameof(NServiceBusSettings)).Get<NServiceBusSettings>() ?? throw new Exception("NServiceBus settings not found");

        var endpointConfiguration = new EndpointConfiguration(settings.EndpointName);

        // Configure Metrics and Monitoring
        endpointConfiguration.SendFailedMessagesTo("error");
        endpointConfiguration.AuditProcessedMessagesTo("audit");
        var metrics = endpointConfiguration.EnableMetrics();
        // metrics.SendMetricDataToServiceControl("Particular.Monitoring", TimeSpan.FromMilliseconds(500));

        // Configure Transport with Azure Service Bus
        var transport = new AzureServiceBusTransport(settings.TransportConnectionString);
        endpointConfiguration.UseTransport(transport);

        // Configure topics
        transport.Topology = TopicTopology.Single(topicName: settings.Topic);
        transport.EntityMaximumSize = 2;
        transport.PrefetchCount = 5;

        endpointConfiguration.UseSerialization<SystemJsonSerializer>();

        // Operational scripting: https://docs.particular.net/transports/azure-service-bus/operational-scripting
        endpointConfiguration.EnableInstallers();

        _instance = await Endpoint.Start(endpointConfiguration).ConfigureAwait(false);
    }

    public void Dispose()
    {
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }

    public async ValueTask DisposeAsync()
    {
        await DisposeAsyncCore();

        Dispose(disposing: false);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (disposing)
        {
            // _instance.Stop();
        }
    }

    protected virtual async ValueTask DisposeAsyncCore()
    {
        await _instance.Stop();
        await Task.CompletedTask;
    }

    public async Task SendCommandAsync<T>(T cmd) where T : ICommand
    {
        await _instance.Send(cmd);
    }

    public async Task PublishEventAsync<T>(T evt) where T : IEvent
    {
        await _instance.Publish(evt);
    }
}
