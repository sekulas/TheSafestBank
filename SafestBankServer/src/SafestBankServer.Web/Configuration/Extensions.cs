using SafestBankServer.Web.Configuration.Exceptions;

namespace SafestBankServer.Web.Configuration;
public static class Extensions
{
    public static IServiceCollection AddWeb(
        this IServiceCollection services
    )
    {
        services.AddExceptionHandler<GlobalExceptionHandler>();

        return services;
    }
}

