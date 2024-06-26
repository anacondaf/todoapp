﻿namespace Infrastructure.Persistences;

using Domain;
using Domain.Commons.Contracts;
using Domain.Models;
using Infrastructure.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

public class ApplicationDbContext(DbContextOptions options) : IdentityDbContext<ApplicationUser>(options), IApplicationDbContext
{
    //public delegate ApplicationDbContext TenantFactory(Guid tenantId);

    public DbSet<Tag> Tags { get; set; }
    public DbSet<TagTodoItem> TagTypes { get; set; }
    public DbSet<TodoItem> TodoItems { get; set; }
    public DbSet<Workspace> Workspaces { get; set; }
    public DbSet<__EFSeedHistory> __EFSeedHistory { get; set; }
    public DbSet<ApplicationUser> ApplicationUsers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<ApplicationUser>(b =>
        {
            b.ToTable(nameof(ApplicationUser));
            b.Property(u => u.Initials).HasMaxLength(50);
        });
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
