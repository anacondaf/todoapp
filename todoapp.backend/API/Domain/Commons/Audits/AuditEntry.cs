using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Commons.Audits;

public class AuditEntry
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }
    public string EntityName { get; set; }
    public string ActionType { get; set; }
    public DateTime TimeStamp { get; set; }
    public string EntityId { get; set; }
}
