namespace SafestBankServer.Application.Exceptions.PasswordReset;
public class PasswordResetAttemptsExceeded(string message) : Exception(message)
{
}
