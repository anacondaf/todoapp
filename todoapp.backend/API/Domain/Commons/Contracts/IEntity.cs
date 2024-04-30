using Domain.Primitives;

namespace Domain.Commons.Contracts;

public interface IEntity<TId> : IEntity
{
    TId Id { get; }
}

public interface IEntity
{
    List<DomainEvent> DomainEvents { get; }
}