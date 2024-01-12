namespace SafestBankServer.Application.Exceptions.Transaction;
public class InvalidTransactionException(string message) : Exception(message)
{
}
