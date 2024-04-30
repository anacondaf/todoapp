using Application.Commons.Events;
using Domain.Primitives;
using MediatR;

namespace Infrastructure.Commons.Services;

public class EventPublisher(IPublisher mediator) : IEventPublisher
{
    private readonly IPublisher _mediator = mediator;

    public Task PublishAsync(DomainEvent @event)
    {
        return _mediator.Publish(CreateEventNotification(@event));
    }

    public INotification CreateEventNotification(DomainEvent @event)
    {
        var genericTypeCollection = new Type[] { @event.GetType() };

        return
            (INotification)Activator
            .CreateInstance(
                typeof(EventNotification<>).MakeGenericType(genericTypeCollection), @event)!;
    }
}
