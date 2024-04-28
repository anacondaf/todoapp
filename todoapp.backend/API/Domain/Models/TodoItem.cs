namespace Domain.Models;

using Domain.Commons.Contracts;

public sealed class TodoItem : AuditableEntity
{
    public string Title { get; set; }
    public string SubTitle { get; set; }

    public ICollection<TagTodoItem> TagTodoItems { get; set; }
}
