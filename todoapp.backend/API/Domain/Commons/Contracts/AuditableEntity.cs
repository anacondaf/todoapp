namespace Domain.Commons.Contracts;

public abstract class AuditableEntity : AuditableEntity<DefaultIdType>
{
}

public abstract class AuditableEntity<T> : BaseEntity<T>
{
    public DateTime CreatedOn { get; set; } = DateTime.UtcNow;

    public DateTime? LastModifiedOn { get; set; } = DateTime.UtcNow;

    public DateTime? DeletedOn { get; set; }

    public Guid CreatedBy { get; set; }

    public Guid LastModifiedBy { get; set; }

    public Guid? DeletedBy { get; set; }
}
