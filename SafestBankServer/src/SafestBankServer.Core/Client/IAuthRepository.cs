namespace SafestBankServer.Core.Client;
public interface IClientRepository
{
    Task<BankClient?> GetClientByIdAsync(Guid clientId);
    Task<BankClient?> GetClientByClientNumberAsync(string clientNumber);
    Task<BankClient?> GetClientByAccountNumberAsync(string accountNumber);
    Task UpdateClientAsync(BankClient client);
}
