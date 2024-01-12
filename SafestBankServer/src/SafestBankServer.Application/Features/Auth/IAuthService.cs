using SafestBankServer.Application.Features.Auth.DTO;

namespace SafestBankServer.Application.Auth;
public interface IAuthService
{
    Task<int[]> GetPasswordMaskAsync(ClientNumberDto clientNumberDto);
    Task<Guid> LoginAsync(ClientLoginDto clientLoginDto);
}
