using Microsoft.Extensions.DependencyInjection;
using SafestBankServer.Application.Auth;
using SafestBankServer.Application.Auth.Passwords;
using SafestBankServer.Application.Configuration;
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

        return services;
    }
}
