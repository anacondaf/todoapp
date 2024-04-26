using Domain.Commons;

namespace Domain;

public class TagTodoItem : BaseEntity
{
    public Guid TagId { get; set; }
    public Guid TodoItemId { get; set; }

    public virtual TodoItem TodoItem { get; set; }
    public virtual Tag Tag { get; set; }
}
