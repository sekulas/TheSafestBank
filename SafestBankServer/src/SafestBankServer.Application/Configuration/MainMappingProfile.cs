using AutoMapper;
using SafestBankServer.Application.DTO.Client;
using SafestBankServer.Application.DTO.Transaction;
using SafestBankServer.Core.Client;
using SafestBankServer.Core.Transaction;

namespace SafestBankServer.Application.Configuration;
public class MainMappingProfile : Profile
{
    public MainMappingProfile()
    {
        CreateMap<BankClient, BankClientDto>();
        CreateMap<ClientTransaction, ClientTransactionDto>();
    }
}
