using SafestBankServer.Core.Client;

namespace SafestBankServer.Core.Auth;
public interface IAuthRepository
{
    Task<BankClient?> GetClientByNumberAsync(string clientNumber);
    Task UpdateClientAsync(BankClient client);
}
