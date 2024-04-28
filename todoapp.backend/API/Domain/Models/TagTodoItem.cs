namespace Domain.Models;

using Domain.Commons.Contracts;

public sealed class TagTodoItem : AuditableEntity
{
    public Guid TagId { get; set; }
    public Guid TodoItemId { get; set; }

    public TodoItem TodoItem { get; set; }
    public Tag Tag { get; set; }
}
