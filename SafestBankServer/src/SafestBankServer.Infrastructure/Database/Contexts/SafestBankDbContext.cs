using Microsoft.EntityFrameworkCore;
using SafestBankServer.Application.Auth.Passwords;
using SafestBankServer.Application.Features.Encryption;
using SafestBankServer.Core.Auth.Passwords;
using SafestBankServer.Core.Client;
using SafestBankServer.Core.Client.Data;
using SafestBankServer.Core.Transaction;

namespace SafestBankServer.Infrastructure.EF.Contexts;
internal sealed class SafestBankDbContext : DbContext
{
    public DbSet<BankClient> BankClients { get; set; }
    public DbSet<Address> Addresses { get; set; }
    public DbSet<PartialPassword> PartialPasswords { get; set; }
    public DbSet<IdentityCard> IdentityCards { get; set; }
    public DbSet<ClientTransaction> ClientTransactions { get; set; }

    public SafestBankDbContext(DbContextOptions<SafestBankDbContext> options)
    : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //TODO - USUN TO
        var _passwordManager = new PasswordManager(new SecurityOptions());
        var _encryptionManager = new EncryptionManager("bA3EOFZKtlQvsGkM");

        modelBuilder.Entity<BankClient>()
            .HasMany(bc => bc.PartialPasswords)
            .WithOne()
            .HasForeignKey(pp => pp.BankClientId);

        modelBuilder.Entity<BankClient>()
            .HasOne(bc => bc.Address)
            .WithOne()
            .HasForeignKey<Address>(a => a.BankClientId);

        modelBuilder.Entity<BankClient>()
            .HasOne(bc => bc.IdentityCard)
            .WithOne()
            .HasForeignKey<IdentityCard>(ic => ic.BankClientId);

        var salt = _encryptionManager.GenerateIV();
        var clientNumber = "123456789012";
        var accountNumber = "12345678901234567890123456";
        var balance = 1000.0m;
        var clientName = "Sebastian";
        var clientSurname = "Sekula";
        var clientPESEL = _encryptionManager.Encrypt("12345678901", salt);
        var clientEmail = "sekula.sebastian.kontakt@gmail.com";
        var clientPassword = "1234QWER!@#$qwer";

        var address = new Address("Poland", 
            _encryptionManager.Encrypt("Warsaw", salt), 
            _encryptionManager.Encrypt("Grojecka", salt), 
            _encryptionManager.Encrypt("39", salt), 
            _encryptionManager.Encrypt("12-102", salt)
            );

        var identityCard = new IdentityCard(
             _encryptionManager.Encrypt("Polish Identity Card", salt),
             _encryptionManager.Encrypt("CDE", salt),
             _encryptionManager.Encrypt("123456", salt),
             "Poland"
             );

        var bankClient = new BankClient(
                clientNumber,
                accountNumber,
                balance,
                clientName,
                clientSurname,
                clientPESEL,
                clientEmail,
                salt
            );

        bankClient.AddressId = address.Id;
        bankClient.IdentityCardId = identityCard.Id;

        address.BankClientId = bankClient.Id;
        identityCard.BankClientId = bankClient.Id;


        modelBuilder.Entity<BankClient>().HasData(
            bankClient
        );

        modelBuilder.Entity<Address>().HasData(
            address
        );

        var partialPasswordList = _passwordManager.GenerateHashedPartialPasswords(clientPassword);
        foreach(var pp in partialPasswordList)
        {
            pp.BankClientId = bankClient.Id;
        }

        modelBuilder.Entity<PartialPassword>().HasData(
            partialPasswordList
        );

        modelBuilder.Entity<IdentityCard>().HasData(
            identityCard
        );

        salt = _encryptionManager.GenerateIV();
        clientNumber = "223456789012";
        accountNumber = "22345678901234567890123456";
        balance = 1000.0m;
        clientName = "Bob";
        clientSurname = "Bobkins";
        clientPESEL = _encryptionManager.Encrypt("22345678901", salt);
        clientEmail = "bob.bobkins@gmail.com";
        clientPassword = "ZXCV!@#$qwer1234";

        address = new Address("Poland",
            _encryptionManager.Encrypt("Lapy", salt),
            _encryptionManager.Encrypt("Lapska", salt),
            _encryptionManager.Encrypt("16", salt),
            _encryptionManager.Encrypt("18-100", salt)
            );

        identityCard = new IdentityCard(
             _encryptionManager.Encrypt("Polish Identity Card", salt),
             _encryptionManager.Encrypt("CDE", salt),
             _encryptionManager.Encrypt("223456", salt),
             "Poland"
             );

        bankClient = new BankClient(
                clientNumber,
                accountNumber,
                balance,
                clientName,
                clientSurname,
                clientPESEL,
                clientEmail,
                salt
            );

        bankClient.AddressId = address.Id;
        bankClient.IdentityCardId = identityCard.Id;

        address.BankClientId = bankClient.Id;
        identityCard.BankClientId = bankClient.Id;


        modelBuilder.Entity<BankClient>().HasData(
            bankClient
        );

        modelBuilder.Entity<Address>().HasData(
            address
        );

        partialPasswordList = _passwordManager.GenerateHashedPartialPasswords(clientPassword);
        foreach(var pp in partialPasswordList)
        {
            pp.BankClientId = bankClient.Id;
        }

        modelBuilder.Entity<PartialPassword>().HasData(
            partialPasswordList
        );

        modelBuilder.Entity<IdentityCard>().HasData(
            identityCard
        );

        salt = _encryptionManager.GenerateIV();
        clientNumber = "323456789012";
        accountNumber = "32345678901234567890123456";
        balance = 1000.0m;
        clientName = "Scott";
        clientSurname = "Scottkins";
        clientPESEL = _encryptionManager.Encrypt("32345678901", salt);
        clientEmail = "scotty123@gmail.com";
        clientPassword = "!QAZ@WSX1qaz2wsx";

        address = new Address("Poland",
            _encryptionManager.Encrypt("Bialystok", salt),
            _encryptionManager.Encrypt("Bialostocka", salt),
            _encryptionManager.Encrypt("1", salt),
            _encryptionManager.Encrypt("12-356", salt)
            );

        identityCard = new IdentityCard(
             _encryptionManager.Encrypt("Polish Identity Card", salt),
             _encryptionManager.Encrypt("CDE", salt),
             _encryptionManager.Encrypt("323456", salt),
             "Poland"
             );

        bankClient = new BankClient(
                clientNumber,
                accountNumber,
                balance,
                clientName,
                clientSurname,
                clientPESEL,
                clientEmail,
                salt
            );

        bankClient.AddressId = address.Id;
        bankClient.IdentityCardId = identityCard.Id;

        address.BankClientId = bankClient.Id;
        identityCard.BankClientId = bankClient.Id;


        modelBuilder.Entity<BankClient>().HasData(
            bankClient
        );

        modelBuilder.Entity<Address>().HasData(
            address
        );

        partialPasswordList = _passwordManager.GenerateHashedPartialPasswords(clientPassword);
        foreach(var pp in partialPasswordList)
        {
            pp.BankClientId = bankClient.Id;
        }

        modelBuilder.Entity<PartialPassword>().HasData(
            partialPasswordList
        );

        modelBuilder.Entity<IdentityCard>().HasData(
            identityCard
        );
    }
}
