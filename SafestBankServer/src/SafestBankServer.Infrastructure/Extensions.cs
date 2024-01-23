using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SafestBankServer.Core.Client;
using SafestBankServer.Core.Transaction;
using SafestBankServer.Infrastructure.EF.Contexts;
using SafestBankServer.Infrastructure.Repositories;

namespace SafestBankServer.Infrastructure;
public static class Extensions
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services
    )
    {
        services.AddScoped<IClientRepository, ClientRepository>();
        services.AddScoped<ITransactionRepository, TransactionRepository>();

        services.AddDbContext<SafestBankDbContext>(o =>
            o.UseNpgsql("Server=localhost;Database=thesafestbankdb;Port=5432;User Id=thesafestbank-server;Password=Vch6mSw0rKjcGlBZCbvu;")
        );

        return services;
    }
}
