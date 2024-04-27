using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistences.Configurations;

public class TagTodoItemConfig : IEntityTypeConfiguration<TagTodoItem>
{
    public void Configure(EntityTypeBuilder<TagTodoItem> builder)
    {
        builder
            .HasKey(tt => new { tt.TagId, tt.TodoItemId });
    }
}
