using MassTransit;

namespace Domain.Commons;

public abstract class BaseEntity
{
    public Guid Id { get; set; } = NewId.NextGuid();
}
