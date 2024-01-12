using AutoMapper;
using SafestBankServer.Application.Exceptions.Auth;
using SafestBankServer.Application.Features.Client.DTO;
using SafestBankServer.Core.Client;

namespace SafestBankServer.Application.Features.Client;
internal sealed class ClientService : IClientService
{
    private readonly IClientRepository _clientRepository;
    private readonly IMapper _mapper;
    public ClientService(IClientRepository clientRepository, IMapper mapper)
    {
        _clientRepository = clientRepository;
        _mapper = mapper;
    }
    public async Task<BankClientDto> GetClientAsync(Guid clientId)
    {
        var client = await _clientRepository.GetClientByIdAsync(clientId)
            ?? throw new BankClientNotFoundException("Cannot find a client.");

        var clientDto = _mapper.Map<BankClientDto>(client);

        return clientDto;
    }
}
