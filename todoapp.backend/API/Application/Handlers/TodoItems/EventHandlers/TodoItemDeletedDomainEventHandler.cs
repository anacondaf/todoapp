using Application.Commons.Events;
using Domain.DomainEvents;
using Domain.Models;

namespace Application.Handlers.TodoItems.EventHandlers;

public class TodoItemDeletedDomainEventHandler : EventNotificationHandler<TodoItemDeletedDomainEvent<TodoItem>>
{
    public override Task HandleEvent(TodoItemDeletedDomainEvent<TodoItem> @event, CancellationToken cancellation)
    {
        Console.WriteLine(@event.Entity.Id);
        return Task.CompletedTask;
    }
}