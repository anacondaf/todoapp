using Application.Commons.Events;
using Domain.DomainEvents;
using Domain.Models;
using MediatR;

namespace Application.Handlers.TodoItems;

public class DeleteTodoItemRequest : IRequest<Guid>
{
    public Guid Id { get; set; }

    public DeleteTodoItemRequest(Guid id) => Id = id;
}

public class DeleteTodoItemRequestHandlers : IRequestHandler<DeleteTodoItemRequest, Guid>
{
    private readonly IEventPublisher _eventPublisher;

    public DeleteTodoItemRequestHandlers(IEventPublisher eventPublisher)
    {
        _eventPublisher = eventPublisher;
    }

    public async Task<Guid> Handle(DeleteTodoItemRequest request, CancellationToken cancellationToken)
    {
        var todoItems = new List<TodoItem>() {
            new() { Id = Guid.Parse("123e4567-e89b-12d3-a456-426655440000"), Title = "Todo1" },
            new() { Title = "Todo2" }
        };

        var todoItem = todoItems.Find(t => t.Id == request.Id);

        await _eventPublisher.PublishAsync(new TodoItemDeletedDomainEvent<TodoItem>(todoItem!));

        return todoItem!.Id;
    }
}
