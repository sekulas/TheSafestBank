using AutoMapper;
using SafestBankServer.Application.DTO;
using SafestBankServer.Application.DTO.Auth;
using SafestBankServer.Application.DTO.Client;
using SafestBankServer.Application.Exceptions.Auth;
using SafestBankServer.Core.Auth;
using SafestBankServer.Core.Auth.Passwords;
using SafestBankServer.Core.Client;

namespace SafestBankServer.Application.Auth;
internal sealed class AuthService : IAuthService
{
    private readonly IAuthRepository _authRepository;
    private readonly IPasswordManager _passwordManager;
    private readonly IMapper _mapper;
    public AuthService(IAuthRepository authRepository, IMapper mapper, IPasswordManager passwordManager)
    {
        _authRepository = authRepository;
        _passwordManager = passwordManager;
        _mapper = mapper;
    }
    public async Task<int[]> GetPasswordMaskAsync(ClientNumberDto clientNumberDto)
    {
        var client = await _authRepository.GetClientByNumberAsync(clientNumberDto.ClientNumber) 
            ?? throw new BankClientNotFound("Cannot find a client.");

        var partialPassword = GetCurrentPartialPasswordForAClient(client);

        return partialPassword.Mask;
    }

    public async Task<BankClientDto> LoginAsync(ClientLoginDto clientLoginDto)
    {
        var client = await _authRepository.GetClientByNumberAsync(clientLoginDto.ClientNumber) 
            ?? throw new BankClientNotFound("Cannot find a client.");

        var partialPassword = GetCurrentPartialPasswordForAClient(client);
        
        if(!_passwordManager.VerifyPassword(clientLoginDto.GivenPassword, partialPassword))
        {
            throw new InvalidPassword("Invalid password.");
        }

        partialPassword.PasswordStatus = PasswordStatus.USED;
        _authRepository.UpdateClientAsync(client);

        var clientDto = _mapper.Map<BankClientDto>(client);

        return clientDto;
    }

    private PartialPassword GetCurrentPartialPasswordForAClient(BankClient client)
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

            _authRepository.UpdateClientAsync(client);
        }

        return partialPassword;
    }
}
