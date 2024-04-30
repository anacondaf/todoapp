using Domain.Commons.Contracts;
using Domain.Primitives;

namespace Domain.DomainEvents;


public sealed class TodoItemDeletedDomainEvent<TEntity>(TEntity Entity) : DomainEvent
    where TEntity : IEntity
{
    public TEntity Entity { get; } = Entity;
}
