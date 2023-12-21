using SafestBankServer.Core.Client.Data;

namespace SafestBankServer.Application.DTO.Client;
public class BankClientDto
{
    public string ClientNumber { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string PESEL { get; set; }
    public string Email { get; set; }
    public Address Address { get; set; }
    public IdentityCard IdentityCard { get; set; }
}
