using Domain.Commons.Contracts;

namespace Domain.Models;

public class Workspace : BaseEntity
{
    public string Email { get; set; }
    public string WebDomain { get; set; }
    public Guid TenantId { get; set; }
}
