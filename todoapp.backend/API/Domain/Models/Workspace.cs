namespace Domain.Models;

using Domain.Commons.Contracts;

public sealed class Workspace : AuditableEntity
{
    public string Email { get; set; }

    public string WebDomain { get; set; }

    public Guid TenantId { get; set; }
}
