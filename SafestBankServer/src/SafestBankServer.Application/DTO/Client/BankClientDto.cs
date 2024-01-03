using SafestBankServer.Application.DTO.Transaction;
using SafestBankServer.Core.Client.Data;

namespace SafestBankServer.Application.DTO.Client;
public class BankClientDto
{
    public string ClientNumber { get; set; }
    public string AccountNumber { get; set; }
    public decimal Balance { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string PESEL { get; set; }
    public string Email { get; set; }
    public Address Address { get; set; }
    public IdentityCard IdentityCard { get; set; }
    public IList<ClientTransactionDto>? Transactions { get; set; }
}
