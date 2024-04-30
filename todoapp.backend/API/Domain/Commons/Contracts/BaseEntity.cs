namespace Domain.Commons.Contracts;

using Domain.Primitives;
using MassTransit;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

public abstract class BaseEntity : BaseEntity<DefaultIdType>
{
    protected BaseEntity()
    {
        Id = Id == default ? NewId.NextSequentialGuid() : Id;
    }
}

public abstract class BaseEntity<TId> : IEntity<TId>
{
    public TId Id { get; set; } = default!;

    [NotMapped]
    public List<DomainEvent> DomainEvents => [];

    protected void RaiseDomainEvents(DomainEvent domainEvent)
    {
        DomainEvents.Add(domainEvent);
    }
}