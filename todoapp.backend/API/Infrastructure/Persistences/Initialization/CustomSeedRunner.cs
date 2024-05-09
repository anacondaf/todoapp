using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public interface ICustomSeedRunner
{
    Task RunSeeders();
}

public class CustomSeedRunner : ICustomSeedRunner
{
    private readonly ICustomSeed[] _seeder;

    public CustomSeedRunner(IServiceProvider serviceProvider)
    {
        _seeder = serviceProvider.GetServices<ICustomSeed>().ToArray();
    }

    public async Task RunSeeders()
    {
        foreach (var seeder in _seeder)
        {
            await seeder.Initialize();
        }
    }
}
