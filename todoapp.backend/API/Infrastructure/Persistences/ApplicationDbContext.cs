using System.Reflection;
using Domain;
using Domain.Commons.Audits;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure;

public class ApplicationDbContext(DbContextOptions options) : DbContext(options)
{
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
            {

            }
        }
    }
}
