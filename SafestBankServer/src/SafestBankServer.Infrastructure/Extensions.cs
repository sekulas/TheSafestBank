using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SafestBankServer.Core.Client;
using SafestBankServer.Core.Transaction;
using SafestBankServer.Infrastructure.Database.Configuration;
using SafestBankServer.Infrastructure.EF.Contexts;
using SafestBankServer.Infrastructure.Repositories;

namespace SafestBankServer.Infrastructure;
public static class Extensions
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration
    )
    {
        services.AddScoped<IClientRepository, ClientRepository>();
        services.AddScoped<ITransactionRepository, TransactionRepository>();

        var dbSettings = configuration.GetSection(nameof(DatabaseOptions)).Get<DatabaseOptions>();

        //TODO - USUN ENABLE SENSITIVE DATA LOGGING
        services.AddDbContext<SafestBankDbContext>(o =>
            o.UseNpgsql(dbSettings.ConnectionString)
        );

        return services;
    }
}
