using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistences.Initialization;

internal class ApplicationDbInitializer(ApplicationDbContext dbContext, ApplicationDbSeeder dbSeeder)
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

        if (await dbContext.Database.CanConnectAsync(cancellationToken))
        {
            await dbSeeder.SeedDatabaseAsync(dbContext, cancellationToken);
        }
    }
}