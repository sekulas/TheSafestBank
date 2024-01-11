using SafestBankServer.Core.Auth.Passwords;

namespace SafestBankServer.Core.Client;
public interface IClientRepository
{
    Task<BankClient?> GetClientByIdAsync(Guid clientId);
    Task<BankClient?> GetClientByClientNumberAsync(string clientNumber);
    Task<BankClient?> GetClientByAccountNumberAsync(string accountNumber);
    Task<BankClient?> GetClientByHashedToken(byte[] hashedToken);
    Task UpdateClientAsync(BankClient client);
    Task<bool> IsTokenGeneratingColisions(byte[] hashedToken);
    Task UpdateClientPasswords(BankClient client, List<PartialPassword> partialPasswords);
}
