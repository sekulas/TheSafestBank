namespace SafestBankServer.Application.Exceptions.Transaction;
public class InvalidTransaction(string message) : Exception(message)
{
}
