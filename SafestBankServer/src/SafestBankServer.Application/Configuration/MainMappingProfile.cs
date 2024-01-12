using AutoMapper;
using SafestBankServer.Application.Features.Client.DTO;
using SafestBankServer.Application.Features.Transaction.Transaction;
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
