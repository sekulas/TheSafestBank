namespace SafestBankServer.Application.Exceptions.PasswordReset;
internal class PasswordResetRequestTimeNotExpiredException(string message) : Exception(message)
{
}
