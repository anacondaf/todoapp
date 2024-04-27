using System.Reflection;
using Domain.Commons.Audits;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistences;

public class ApplicationDbContext(DbContextOptions options, Guid tenantId) : DbContext(options)
{
    public delegate ApplicationDbContext TenantFactory(Guid tenantId);

    public DbSet<Tag> Tags { get; set; }
    public DbSet<TagTodoItem> TagTypes { get; set; }
    public DbSet<TodoItem> TodoItems { get; set; }
    public DbSet<Workspace> Workspaces { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(modelBuilder);
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        OnBeforeSavingAsync();
        return base.SaveChangesAsync(cancellationToken);
    }

    private void OnBeforeSavingAsync()
    {
        ChangeTracker.DetectChanges();

        foreach (var entry in ChangeTracker.Entries())
        {
            if (entry.State is EntityState.Detached || entry.State == EntityState.Unchanged || entry.Entity is not AuditableEntity)
                continue;
        }
    }
}
