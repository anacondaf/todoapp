using Domain.Commons.Contracts;

namespace Domain.Models;

public class Tag : BaseEntity
{
    public string Name { get; set; }
    public string HexCode { get; set; }
    public Guid TodoItemId { get; set; }

    public virtual ICollection<TagTodoItem> TagItems { get; set; }
}
