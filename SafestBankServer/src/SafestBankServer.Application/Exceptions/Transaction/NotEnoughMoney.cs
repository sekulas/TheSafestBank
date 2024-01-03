namespace SafestBankServer.Application.Exceptions.Transaction;
public class NotEnoughMoney(string message) : Exception(message)
{
}
