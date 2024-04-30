using Domain.Primitives;
using MediatR;

namespace Application.Commons.Events;

public class EventNotification<TEvent>(TEvent @event) : INotification
       where TEvent : IEvent
{
    public TEvent Event { get; set; } = @event;
}
