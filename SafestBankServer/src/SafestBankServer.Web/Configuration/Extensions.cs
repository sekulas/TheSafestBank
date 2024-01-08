using SafestBankServer.Web.Configuration.Exceptions;
using SafestBankServer.Web.Configuration.Session;

namespace SafestBankServer.Web.Configuration;
internal static class Extensions
{
    public static IServiceCollection AddWeb(
        this IServiceCollection services
    )
    {
        services.AddExceptionHandler<GlobalExceptionHandler>();
        services.AddSingleton<SessionConfiguration>();
        services.AddSingleton<SessionManager>();

        return services;
    }
}

