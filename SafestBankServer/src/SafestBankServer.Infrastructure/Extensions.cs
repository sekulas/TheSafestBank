using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SafestBankServer.Core.Client;
using SafestBankServer.Infrastructure.Auth;
using SafestBankServer.Infrastructure.Database.Configuration;
using SafestBankServer.Infrastructure.EF.Contexts;

namespace SafestBankServer.Infrastructure;
public static class Extensions
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration
    )
    {
        services.AddScoped<IClientRepository, ClientRepository>();

        var dbSettings = configuration.GetSection(nameof(DatabaseOptions)).Get<DatabaseOptions>();

        //TODO - USUN ENABLE SENSITIVE DATA LOGGING
        services.AddDbContext<SafestBankDbContext>(o =>
            o.UseNpgsql(dbSettings.ConnectionString)
                .EnableSensitiveDataLogging()
        );

        return services;
    }
}
