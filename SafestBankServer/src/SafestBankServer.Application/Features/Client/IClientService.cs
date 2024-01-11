using SafestBankServer.Application.Features.Client.DTO;

namespace SafestBankServer.Application.Features.Client;
public interface IClientService
{
    Task<BankClientDto> GetClientAsync(Guid clientId);
}