using SafestBankServer.Application.Exceptions.Auth;
using SafestBankServer.Application.Features.Auth.DTO;
using SafestBankServer.Core.Auth.Passwords;
using SafestBankServer.Core.Client;

namespace SafestBankServer.Application.Auth;
internal sealed class AuthService : IAuthService
{
    private readonly IClientRepository _clientRepository;
    private readonly IPasswordManager _passwordManager;
    public AuthService(IClientRepository clientRepository, IPasswordManager passwordManager)
    {
        _clientRepository = clientRepository;
        _passwordManager = passwordManager;
    }
    public async Task<int[]> GetPasswordMaskAsync(ClientNumberDto clientNumberDto)
    {
        var client = await _clientRepository.GetClientByClientNumberAsync(clientNumberDto.ClientNumber) 
            ?? throw new BankClientNotFoundException("Cannot find a client.");

        var partialPassword = await GetCurrentPartialPasswordForAClient(client);

        return partialPassword.Mask;
    }

    public async Task<Guid> LoginAsync(ClientLoginDto clientLoginDto)
    {
        var client = await _clientRepository.GetClientByClientNumberAsync(clientLoginDto.ClientNumber) 
            ?? throw new BankClientNotFoundException("Invalid credentials.");

        var partialPassword = await GetCurrentPartialPasswordForAClient(client);
        
        if(!_passwordManager.VerifyPassword(clientLoginDto.Password, partialPassword))
        {
            client.LoginAttempts++;

            if(client.LoginAttempts < 4)
            {
                await _clientRepository.UpdateClientAsync(client);
                throw new InvalidPasswordException("Invalid credentials.");
            }
            else
            {
                client.IsBlocked = true;
                await _clientRepository.UpdateClientAsync(client);
                throw new UnauthorizedAccessException("Your account has been blocked. Please contact with the support or change the password using email.");
            }
        }

        if(client.IsBlocked)
        {
            throw new UnauthorizedAccessException("Your account has been blocked. Please contact with the support or change the password using email.");
        }

        partialPassword.PasswordStatus = PasswordStatus.USED;
        await _clientRepository.UpdateClientAsync(client);

        return client.Id;
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

            await _clientRepository.UpdateClientAsync(client);
        }

        return partialPassword;
    }
}
