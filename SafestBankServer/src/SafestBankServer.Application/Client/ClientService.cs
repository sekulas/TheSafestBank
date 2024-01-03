using AutoMapper;
using SafestBankServer.Application.DTO.Client;
using SafestBankServer.Application.Exceptions.Auth;
using SafestBankServer.Core.Client;

namespace SafestBankServer.Application.Client;
internal sealed class ClientService : IClientService
{
    private readonly IClientRepository _clientRepository;
    private readonly IMapper _mapper;
    public ClientService(IClientRepository clientRepository, IMapper mapper)
    {
         _clientRepository = clientRepository;
        _mapper = mapper;
    }
    public async Task<BankClientDto> GetClientAsync(string clientNumber)
    {
        var client = await _clientRepository.GetClientByNumberAsync(clientNumber)
            ?? throw new BankClientNotFound("Cannot find a client.");

        var clientDto = _mapper.Map<BankClientDto>(client);

        return clientDto;
    }
}
