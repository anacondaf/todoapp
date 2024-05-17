
using Domain.Models;
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

    public async Task InitializeAsync(CancellationToken cancellationToken)
    {
        // lock (_locker)
        // {
        //     _context.Seed
        // }

        _logger.LogInformation($"Seeding {nameof(TagTodoItemSeed)}");

        var todoItems = new List<TodoItem>() {
            new() {
                Title = "Meeting with UK client",
            },
            new() {
                Title = "Daily meeting",
            }
        };

        await _context.TodoItems.AddRangeAsync(todoItems);

        _context.__EFSeedHistory.Add(new Domain.__EFSeedHistory()
        {
            Name = nameof(TagTodoItemSeed)
        });

        await _context.SaveChangesAsync(cancellationToken);
    }
}
