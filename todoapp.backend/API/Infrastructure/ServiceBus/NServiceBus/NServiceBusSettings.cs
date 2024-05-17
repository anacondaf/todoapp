namespace Infrastructure;

public class NServiceBusSettings
{
    public string EndpointName { get; set; }
    public string TransportConnectionString { get; set; }
    public string Topic { get; set; }
}