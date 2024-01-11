using Microsoft.AspNetCore.Diagnostics;
using SafestBankServer.Application.Exceptions.Auth;
using SafestBankServer.Application.Exceptions.PasswordReset;
using SafestBankServer.Application.Exceptions.Transaction;

namespace SafestBankServer.Web.Configuration.Exceptions;

public class GlobalExceptionHandler : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        (int statusCode, string message) = exception switch
        {
            InvalidPassword e => (400, e.Message),
            ResetPasswordException e => (400, e.Message),
            PasswordResetAttemptsExceeded e => (401, e.Message),
            UnauthorizedAccessException e => (401, e.Message),
            NotEnoughMoney e => (402, e.Message),
            BankClientNotFound e => (404, e.Message),
            _ => (500, "Internal Server Error")
        };  

        httpContext.Response.StatusCode = statusCode;
        await httpContext.Response.WriteAsJsonAsync(new ExceptionDto { message = message });

        return true;
    }
}
