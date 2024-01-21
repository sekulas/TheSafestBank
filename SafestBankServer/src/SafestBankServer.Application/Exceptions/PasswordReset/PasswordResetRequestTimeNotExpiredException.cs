namespace SafestBankServer.Application.Exceptions.PasswordReset;
public class PasswordResetRequestTimeNotExpiredException(string message) : Exception(message)
{
}
