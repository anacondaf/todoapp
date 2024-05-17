using Infrastructure.Persistences;
using Microsoft.Extensions.Logging;

namespace Infrastructure;

internal class ApplicationDbSeeder
{
    private readonly ICustomSeederRunner _seederRunner;
    private readonly ILogger<ApplicationDbSeeder> logger;

    public ApplicationDbSeeder(ICustomSeederRunner seederRunner, ILogger<ApplicationDbSeeder> logger)
    {
        _seederRunner = seederRunner;
        this.logger = logger;
    }

    public async Task SeedDatabaseAsync(ApplicationDbContext dbContext, CancellationToken cancellationToken)
    {
        if (!dbContext.__EFSeedHistory.Any())
        {
            logger.LogInformation("Running seeders...");
            await _seederRunner.RunSeedersAsync(dbContext, cancellationToken);
        }
    }
}