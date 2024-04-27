using Infrastructure.Persistences;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure;

public static class Startup
{
    public static IServiceCollection AddPersistence(this IServiceCollection service, IConfiguration configuration)
    {
        var appDbConnectionString = configuration.GetConnectionString("AppDb");

        service.AddDbContext<ApplicationDbContext>(
            opts =>
            {
                opts.UseSqlServer("appDbConnectionString");
                opts.UseQueryTrackingBehavior(QueryTrackingBehavior.TrackAll);
            }
        );

        return service;
    }
}
