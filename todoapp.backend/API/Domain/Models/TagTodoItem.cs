using Domain.Commons.Audits;
using Domain.Commons.Contracts;

namespace Domain.Models;

public class TagTodoItem : AuditableEntity
{
    public Guid TagId { get; set; }
    public Guid TodoItemId { get; set; }

    public virtual TodoItem TodoItem { get; set; }
    public virtual Tag Tag { get; set; }
}
