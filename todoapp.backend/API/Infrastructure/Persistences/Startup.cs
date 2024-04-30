using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistences;

internal static class Startup
{
    internal static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        var appDbConnectionString = configuration.GetConnectionString("AppDb");

        services.AddDbContext<ApplicationDbContext>(
            opts =>
            {
                opts.UseSqlServer("appDbConnectionString");
                opts.UseQueryTrackingBehavior(QueryTrackingBehavior.TrackAll);
            }
        );

        return services;
    }
}
