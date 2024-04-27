using Domain.Commons.Audits;

namespace Domain.Models;

public class TodoItem : AuditableEntity
{
    public string Title { get; set; }
    public string SubTitle { get; set; }

    public virtual ICollection<TagTodoItem> TagTodoItems { get; set; }
}
