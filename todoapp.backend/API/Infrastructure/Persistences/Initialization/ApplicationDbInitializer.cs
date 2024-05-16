using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Persistences.Initialization;

internal class ApplicationDbInitializer(ApplicationDbContext dbContext, ApplicationDbSeeder dbSeeder, ILogger<ApplicationDbInitializer> logger)
{
    public async Task InitializeAsync(CancellationToken cancellationToken)
    {
        if (dbContext.Database.GetMigrations().Any())
        {
            logger.LogInformation("Running migrations...");

            var pendingMigrations = await dbContext.Database.GetPendingMigrationsAsync(cancellationToken);

            if (pendingMigrations.Any())
            {
                await dbContext.Database.MigrateAsync(cancellationToken);
            }
        }

        if (await dbContext.Database.CanConnectAsync(cancellationToken))
        {
            logger.LogInformation("Running seeders...");
            await dbSeeder.SeedDatabaseAsync(dbContext, cancellationToken);
        }
    }
}