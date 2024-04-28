using Domain.Commons.Contracts;

namespace Domain.Models;

public sealed class Tag : AuditableEntity
{
    public string Name { get; set; }

    public string HexCode { get; set; }

    public Guid TodoItemId { get; set; }

    public ICollection<TagTodoItem> TagItems { get; set; }
}
