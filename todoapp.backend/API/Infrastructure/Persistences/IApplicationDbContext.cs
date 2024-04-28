using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistences
{
    public interface IApplicationDbContext
    {
        DbSet<Tag> Tags { get; set; }
        DbSet<TagTodoItem> TagTypes { get; set; }
        DbSet<TodoItem> TodoItems { get; set; }
        DbSet<Workspace> Workspaces { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}