namespace Domain.Models;

using Domain.Commons.Audits;

public class Tag : AuditableEntity
{
    public string Name { get; set; }

    public string HexCode { get; set; }

    public Guid TodoItemId { get; set; }

    public virtual ICollection<TagTodoItem> TagItems { get; set; }
}
