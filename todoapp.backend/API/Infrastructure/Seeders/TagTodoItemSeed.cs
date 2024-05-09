
using Infrastructure.Persistences;
using Microsoft.Extensions.Logging;

namespace Infrastructure;

public class TagTodoItemSeed : ICustomSeeder
{
    private readonly ApplicationDbContext _context;
    private static object _locker = new object();
    private readonly ILogger<TagTodoItemSeed> _logger;

    public TagTodoItemSeed(ApplicationDbContext context, ILogger<TagTodoItemSeed> logger)
    {
        _context = context;
        _logger = logger;
    }

    public Task InitializeAsync(CancellationToken cancellationToken)
    {
        // lock (_locker)
        // {
        //     _context.Seed
        // }

        _logger.LogInformation(nameof(TagTodoItemSeed));

        return Task.CompletedTask;
    }
}
