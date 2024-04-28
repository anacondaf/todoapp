using Domain.Commons.Contracts;

namespace Domain.Models;

public class Workspace : AuditableEntity
{
    public string Email { get; set; }
    public string WebDomain { get; set; }
    public Guid TenantId { get; set; }
}
