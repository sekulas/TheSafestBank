using SafestBankServer.Application.DTO.Auth;
using SafestBankServer.Application.Exceptions.Auth;
using SafestBankServer.Core.Auth.Passwords;
using SafestBankServer.Core.Client;

namespace SafestBankServer.Application.Auth;
internal sealed class AuthService : IAuthService
{
    private readonly IClientRepository _authRepository;
    private readonly IPasswordManager _passwordManager;
    public AuthService(IClientRepository authRepository, IPasswordManager passwordManager)
    {
        _authRepository = authRepository;
        _passwordManager = passwordManager;
    }
    public async Task<int[]> GetPasswordMaskAsync(ClientNumberDto clientNumberDto)
    {
        var client = await _authRepository.GetClientByNumberAsync(clientNumberDto.ClientNumber) 
            ?? throw new BankClientNotFound("Cannot find a client.");

        var partialPassword = await GetCurrentPartialPasswordForAClient(client);

        return partialPassword.Mask;
    }

    public async Task LoginAsync(ClientLoginDto clientLoginDto)
    {
        var client = await _authRepository.GetClientByNumberAsync(clientLoginDto.ClientNumber) 
            ?? throw new BankClientNotFound("Cannot find a client.");

        var partialPassword = await GetCurrentPartialPasswordForAClient(client);
        
        if(!_passwordManager.VerifyPassword(clientLoginDto.Password, partialPassword))
        {
            throw new InvalidPassword("Invalid password.");
        }

        partialPassword.PasswordStatus = PasswordStatus.USED;
        await _authRepository.UpdateClientAsync(client);

        return;
    }

    private async Task<PartialPassword> GetCurrentPartialPasswordForAClient(BankClient client)
    {
        var partialPasswords = client.PartialPasswords.ToList();

        var partialPassword = partialPasswords
            .FirstOrDefault(x => x.PasswordStatus == PasswordStatus.HAS_TO_BE_USED);

        if(partialPassword == null)
        {
            foreach(var password in partialPasswords)
            {
                password.PasswordStatus = PasswordStatus.NOT_USED;
            }

            var randomIndex = _passwordManager.GenerateRandomIndex(partialPasswords.Count);

            partialPasswords[randomIndex].PasswordStatus = PasswordStatus.HAS_TO_BE_USED;
            partialPassword = partialPasswords[randomIndex];

            await _authRepository.UpdateClientAsync(client);
        }

        return partialPassword;
    }
}
