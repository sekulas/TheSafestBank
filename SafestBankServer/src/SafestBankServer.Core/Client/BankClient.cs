using SafestBankServer.Core.Auth.Passwords;
using SafestBankServer.Core.Client.Data;
using SafestBankServer.Core.Transaction;

namespace SafestBankServer.Core.Client;
public class BankClient
{
    public Guid Id { get; protected set; } = Guid.NewGuid();
    public string ClientNumber { get; protected set; }
    public string AccountNumber { get; protected set; }
    public decimal Balance { get; set; }
    public string Name { get; protected set; }
    public string Surname { get; protected set; }
    public string PESEL { get; protected set; }
    public string Email { get; protected set; }
    public Guid AddressId { get; set; }
    public virtual Address Address { get; set; }
    public int LoginAttempts { get; set; }
    public bool IsBlocked { get; set; }
    public virtual IList<PartialPassword> PartialPasswords{ get; set; }
    public int PasswordResetAttempts { get; set; }
    public DateTime? LastPasswordResetRequestTime { get; set; }
    public byte[]? PasswordResetTokenHash { get; set; }
    public Guid IdentityCardId { get; set; }
    public virtual IdentityCard IdentityCard { get; set; }
    public virtual IList<ClientTransaction>? Transactions { get; set; }

    public BankClient(string clientNumber, string accountNumber, decimal balance, string name, string surname, string pESEL, string email)
    {
        ClientNumber = clientNumber;
        AccountNumber = accountNumber;
        Balance = balance;
        Name = name;
        Surname = surname;
        PESEL = pESEL;
        Email = email;
        LoginAttempts = 0;
        IsBlocked = false;
        PasswordResetAttempts = 0;
    }
}
