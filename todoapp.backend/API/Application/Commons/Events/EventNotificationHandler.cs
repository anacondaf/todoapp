using Domain.Primitives;
using MediatR;

namespace Application.Commons.Events;

public abstract class EventNotificationHandler<TEvent> : INotificationHandler<EventNotification<TEvent>>
    where TEvent : DomainEvent
{
    public abstract Task HandleEvent(TEvent @event, CancellationToken cancellation);

    Task INotificationHandler<EventNotification<TEvent>>.Handle(EventNotification<TEvent> notification, CancellationToken cancellationToken)
        => HandleEvent(notification.Event, cancellationToken);
}
