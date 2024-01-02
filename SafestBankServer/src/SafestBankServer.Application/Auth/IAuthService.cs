using SafestBankServer.Application.DTO.Auth;

namespace SafestBankServer.Application.Auth;
public interface IAuthService
{
    Task<int[]> GetPasswordMaskAsync(ClientNumberDto clientNumberDto);
    Task LoginAsync(ClientLoginDto clientLoginDto);
}
