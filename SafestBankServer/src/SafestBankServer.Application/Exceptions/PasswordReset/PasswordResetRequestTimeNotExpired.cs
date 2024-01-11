namespace SafestBankServer.Application.Exceptions.PasswordReset;
internal class PasswordResetRequestTimeNotExpired(string message) : Exception(message)
{
}
