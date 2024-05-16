using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Persistences;

internal static class Startup
{
    internal static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        var appDbConnectionString = configuration.GetSection(nameof(DbSettings)).Get<DbSettings>() ?? throw new Exception("Parse application database ");

        services.AddDbContext<ApplicationDbContext>(
            opts =>
            {
                opts.UseSqlServer(appDbConnectionString.ConnectionString, x =>
                {
                    x.MigrationsAssembly("Migrators.MSSQL");
                    x.MigrationsHistoryTable("__EFMigrationsHistory", "dbo");
                });
                opts.UseQueryTrackingBehavior(QueryTrackingBehavior.TrackAll);
            }
        );

        return services;
    }
}
