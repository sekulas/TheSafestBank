using Microsoft.AspNetCore.Diagnostics;
using SafestBankServer.Application.Exceptions.Auth;

namespace SafestBankServer.Web.Configuration.Exceptions;

public class GlobalExceptionHandler : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        (int statusCode, string title) = exception switch
        {
            BankClientNotFound e => (404, e.Message),
            InvalidPassword e => (400, e.Message),
            _ => (500, "Internal Server Error")
        };  

        httpContext.Response.StatusCode = statusCode;
        await httpContext.Response.WriteAsJsonAsync(new { title });

        return true;
    }
}
