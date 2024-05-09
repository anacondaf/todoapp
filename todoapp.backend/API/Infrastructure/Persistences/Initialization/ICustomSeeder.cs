namespace Infrastructure;

public interface ICustomSeeder
{
    Task InitializeAsync(CancellationToken cancellationToken);
}
