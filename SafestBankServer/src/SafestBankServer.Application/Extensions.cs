using Microsoft.Extensions.DependencyInjection;
using SafestBankServer.Application.Auth;
using SafestBankServer.Application.Auth.Passwords;
using SafestBankServer.Application.Configuration;
using SafestBankServer.Application.Features.Client;
using SafestBankServer.Application.Features.PasswordReset;
using SafestBankServer.Application.Features.Transaction;
using SafestBankServer.Core.Auth.Passwords;

namespace SafestBankServer.Application;
public static class Extensions
{
    public static IServiceCollection AddApplication(
        this IServiceCollection services
    )
    {
        services.AddSingleton<SecurityOptions>();
        services.AddAutoMapper(cfg => cfg.AddProfile<MainMappingProfile>());
        services.AddScoped<IPasswordManager, PasswordManager>();
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<IClientService, ClientService>();
        services.AddScoped<ITransactionService, TransactionService>();
        services.AddScoped<IPasswordResetService, PasswordResetService>();

        return services;
    }
}
