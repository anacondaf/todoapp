using Domain.Commons.Audits;

namespace Domain;

public class TodoItem : AuditableEntity
{
    public string Title { get; set; }
    public string SubTitle { get; set; }

    public virtual ICollection<TagItem> TagItems { get; set; }
}
