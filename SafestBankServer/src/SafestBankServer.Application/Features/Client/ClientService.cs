using AutoMapper;
using SafestBankServer.Application.Exceptions.Auth;
using SafestBankServer.Application.Features.Client.DTO;
using SafestBankServer.Application.Features.Encryption;
using SafestBankServer.Core.Client;

namespace SafestBankServer.Application.Features.Client;
internal sealed class ClientService : IClientService
{
    private readonly IClientRepository _clientRepository;
    private readonly IMapper _mapper;
    private readonly IEncryptionManager _encryptor;
    public ClientService(IClientRepository clientRepository, IMapper mapper, IEncryptionManager encryptor)
    {
        _clientRepository = clientRepository;
        _mapper = mapper;
        _encryptor = encryptor;
    }
    public async Task<BankClientDto> GetClientAsync(Guid clientId)
    {
        var client = await _clientRepository.GetClientByIdAsync(clientId)
            ?? throw new BankClientNotFoundException("Cannot find a client.");

        var decryptedClient = DecryptClient(client);

        var clientDto = _mapper.Map<BankClientDto>(decryptedClient);

        return clientDto;
    }

    private BankClient DecryptClient(BankClient client)
    {
        client.IdentityCard.Type = _encryptor.Decrypt(client.IdentityCard.Type, client.Salt);
        client.IdentityCard.Serie = _encryptor.Decrypt(client.IdentityCard.Serie, client.Salt);
        client.IdentityCard.Number = _encryptor.Decrypt(client.IdentityCard.Number, client.Salt);

        client.Address.City = _encryptor.Decrypt(client.Address.City, client.Salt);
        client.Address.HouseNumber = _encryptor.Decrypt(client.Address.HouseNumber, client.Salt);
        client.Address.Street = _encryptor.Decrypt(client.Address.Street, client.Salt);
        client.Address.ZipCode = _encryptor.Decrypt(client.Address.ZipCode, client.Salt);

        return client;
    }
}
