
using Infrastructure.Persistences;

namespace Infrastructure;

public class TagTodoItemSeed : ICustomSeed
{
    private readonly ApplicationDbContext _context;
    private static object _locker = new object();

    public TagTodoItemSeed(ApplicationDbContext context)
    {
        _context = context;
    }

    public Task Initialize()
    {
        lock(_locker) {
            _context.Seed
        }
    }
}
