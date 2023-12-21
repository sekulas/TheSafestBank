using SafestBankServer.Core.Auth.Passwords;
using SafestBankServer.Core.Client.Data;

namespace SafestBankServer.Core.Client;
public class BankClient
{
    public Guid Id { get; protected set; } = Guid.NewGuid();
    public string ClientNumber { get; protected set; }
    public string Name { get; protected set; }
    public string Surname { get; protected set; }
    public string PESEL { get; protected set; }
    public string Email { get; protected set; }
    public Guid AddressId { get; set; }
    public virtual Address Address { get; set; }
    public virtual IList<PartialPassword> PartialPasswords{ get; set; }
    public Guid IdentityCardId { get; set; }
    public virtual IdentityCard IdentityCard { get; set; }

    public BankClient(string clientNumber, string name, string surname, string pESEL, string email)
    {
        ClientNumber = clientNumber;
        Name = name;
        Surname = surname;
        PESEL = pESEL;
        Email = email;
    }
}
