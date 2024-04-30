namespace Domain.Primitives;

public class DomainEvent : IEvent
{
    public DateTime TriggeredOn { get; private set; } = DateTime.UtcNow;
}
