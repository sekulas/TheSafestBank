using SafestBankServer.Application.DTO.Auth;
using SafestBankServer.Application.DTO.Client;

namespace SafestBankServer.Application.Auth;
public interface IAuthService
{
    Task<int[]> GetPasswordMaskAsync(ClientNumberDto clientNumberDto);
    Task<BankClientDto> LoginAsync(ClientLoginDto clientLoginDto);
}
