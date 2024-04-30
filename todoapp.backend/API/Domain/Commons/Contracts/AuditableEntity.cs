namespace Domain.Commons.Contracts;

public abstract class AuditableEntity : BaseEntity, IAuditableEntity, ISoftDelete
{
    public DateTime CreatedOn { get; set; } = DateTime.UtcNow;

    public DateTime? LastModifiedOn { get; set; } = DateTime.UtcNow;

    public Guid CreatedBy { get; set; }

    public Guid LastModifiedBy { get; set; }

    public Guid? DeletedBy { get; set; }

    public DateTime? DeletedOn { get; set; }

    protected AuditableEntity()
    {
        CreatedOn = DateTime.UtcNow;
        LastModifiedOn = DateTime.UtcNow;
    }
}