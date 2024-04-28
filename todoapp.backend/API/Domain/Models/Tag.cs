namespace Domain.Models;

using Domain.Commons.Contracts;

public sealed class Tag : AuditableEntity
{
    public string Name { get; set; }

    public string HexCode { get; set; }

    public Guid TodoItemId { get; set; }

    public ICollection<TagTodoItem> TagItems { get; set; }
}
