using Domain.Commons.Contracts;

namespace Domain.Models;

public sealed class TodoItem : AuditableEntity
{
    public string Title { get; set; }
    public string SubTitle { get; set; }

    public ICollection<TagTodoItem> TagTodoItems { get; set; }
}
