using Infrastructure.Persistences;

namespace Infrastructure;

internal class ApplicationDbSeeder
{
    private readonly ICustomSeederRunner _seederRunner;

    public ApplicationDbSeeder(ICustomSeederRunner seederRunner)
    {
        _seederRunner = seederRunner;
    }

    public async Task SeedDatabaseAsync(ApplicationDbContext dbContext, CancellationToken cancellationToken)
    {
        await _seederRunner.RunSeedersAsync(cancellationToken);
    }
}