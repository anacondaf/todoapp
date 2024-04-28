namespace Domain.Commons.Contracts;

using MassTransit;

public abstract class BaseEntity : BaseEntity<DefaultIdType>
{
    protected BaseEntity() => Id = NewId.NextGuid();
}

public abstract class BaseEntity<TId> : IEntity<TId>
{
    public TId Id { get; protected set; } = default!;
}