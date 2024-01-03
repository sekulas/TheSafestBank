using SafestBankServer.Application.DTO.Client;

namespace SafestBankServer.Application.Client;
public interface IClientService
{
    Task<BankClientDto> GetClientAsync(string clientNumber);
}