using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Persistences.Initialization;

internal class ApplicationDbInitializer(ApplicationDbContext dbContext, ApplicationDbSeeder dbSeeder, ILogger<ApplicationDbInitializer> logger)
{
    public async Task InitializeAsync(CancellationToken cancellationToken)
    {
        var pendingMigrations = await dbContext.Database.GetPendingMigrationsAsync(cancellationToken);

        if (pendingMigrations.Any())
        {
            logger.LogInformation("Running migrations...");

            await dbContext.Database.MigrateAsync(cancellationToken);
        }

        if (await dbContext.Database.CanConnectAsync(cancellationToken))
        {
            await dbSeeder.SeedDatabaseAsync(dbContext, cancellationToken);
        }
    }
}