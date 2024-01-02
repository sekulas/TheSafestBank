namespace SafestBankServer.Core.Client;
public interface IClientRepository
{
    Task<BankClient?> GetClientByNumberAsync(string clientNumber);
    Task UpdateClientAsync(BankClient client);
}
