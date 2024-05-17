using MediatR;

namespace Application.Commons.Events;

public class EventNotification<TEvent>(TEvent @event) : INotification
       where TEvent : Domain.Primitives.IEvent
{
    public TEvent Event { get; set; } = @event;
}
