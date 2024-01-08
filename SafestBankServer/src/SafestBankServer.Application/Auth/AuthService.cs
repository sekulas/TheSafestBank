using AutoMapper;
using SafestBankServer.Application.DTO.Auth;
using SafestBankServer.Application.Exceptions.Auth;
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
            ?? throw new BankClientNotFound("Cannot find a client.");

        var partialPassword = await GetCurrentPartialPasswordForAClient(client);

        return partialPassword.Mask;
    }

    public async Task<Guid> LoginAsync(ClientLoginDto clientLoginDto)
    {
        var client = await _clientRepository.GetClientByClientNumberAsync(clientLoginDto.ClientNumber) 
            ?? throw new BankClientNotFound("Cannot find a client.");

        var partialPassword = await GetCurrentPartialPasswordForAClient(client);
        
        if(!_passwordManager.VerifyPassword(clientLoginDto.Password, partialPassword))
        {
            throw new InvalidPassword("Invalid password.");
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
