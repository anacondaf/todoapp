using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistences.Initialization;

internal class ApplicationDbInitializer(ApplicationDbContext dbContext)
{
    public async Task InitializeAsync(CancellationToken cancellationToken)
    {
        if (dbContext.Database.GetMigrations().Any())
        {
            var pendingMigrations = await dbContext.Database.GetPendingMigrationsAsync(cancellationToken);
            if (pendingMigrations.Any())
            {
                await dbContext.Database.MigrateAsync(cancellationToken);
            }
        }
    }
}

public static class PersistenceExtensions
{
    public static async Task InitializeDatabasesAsync(this IServiceProvider services, CancellationToken cancellationToken)
    {
        using var scope = services.CreateScope();

        await scope.ServiceProvider.GetRequiredService<ApplicationDbInitializer>().InitializeAsync(cancellationToken);
    }
}