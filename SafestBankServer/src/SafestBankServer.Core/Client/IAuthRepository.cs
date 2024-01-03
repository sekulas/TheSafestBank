namespace SafestBankServer.Core.Client;
public interface IClientRepository
{
    Task<BankClient?> GetClientByNumberAsync(string clientNumber);
    Task<BankClient?> GetClientByAccountNumberAsync(string accountNumber);
    Task UpdateClientAsync(BankClient client);
}
