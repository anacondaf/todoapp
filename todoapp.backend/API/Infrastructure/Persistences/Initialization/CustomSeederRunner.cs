using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

internal interface ICustomSeederRunner
{
    Task RunSeedersAsync(CancellationToken cancellationToken);
}


internal class CustomSeederRunner : ICustomSeederRunner
{
    private readonly ICustomSeeder[] _seeders;

    public CustomSeederRunner(IServiceProvider serviceProvider) =>
        _seeders = serviceProvider.GetServices<ICustomSeeder>().ToArray();

    public async Task RunSeedersAsync(CancellationToken cancellationToken)
    {
        foreach (var seeder in _seeders)
        {
            await seeder.InitializeAsync(cancellationToken);
        }
    }
}