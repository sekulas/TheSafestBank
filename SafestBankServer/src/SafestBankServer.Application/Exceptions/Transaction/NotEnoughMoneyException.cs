namespace SafestBankServer.Application.Exceptions.Transaction;
public class NotEnoughMoneyException(string message) : Exception(message)
{
}
