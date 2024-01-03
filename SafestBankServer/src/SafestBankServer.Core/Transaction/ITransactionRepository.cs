namespace SafestBankServer.Core.Transaction;
public interface ITransactionRepository
{
    Task AddTransactionAsync(ClientTransaction transaction);
    Task<IList<ClientTransaction>?> GetClientTransactions(Guid clientId);
}
