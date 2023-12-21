using AutoMapper;
using SafestBankServer.Application.DTO.Client;
using SafestBankServer.Core.Client;

namespace SafestBankServer.Application.Configuration;
public class MainMappingProfile : Profile
{
    public MainMappingProfile()
    {
        CreateMap<BankClient, BankClientDto>();
    }
}
