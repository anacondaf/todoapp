using Domain.Commons.Contracts;

namespace Domain.Commons.Audits;

public abstract class AuditableEntity : AuditableEntity<DefaultIdType>
{
}

public abstract class AuditableEntity<T> : BaseEntity<T>
{
    public DateTime CreatedOn { get; set; }
    public DateTime? LastModifiedOn { get; set; }
    public DateTime? DeletedOn { get; set; }

    public Guid CreatedBy { get; set; }
    public Guid LastModifiedBy { get; set; }
    public Guid? DeletedBy { get; set;}

    protected AuditableEntity()
    {
        CreatedOn = DateTime.UtcNow;
        LastModifiedOn = DateTime.UtcNow;
    }
}
