using Microsoft.EntityFrameworkCore;
using SafestBankServer.Application.Auth.Passwords;
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
        var _passwordManager = new PasswordManager(new SecurityOptions());

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

        var clientNumber = "1";
        var accountNumber = "12345678901234567890123456";
        var balance = 1000.0m;
        var clientName = "Sebastian";
        var clientSurname = "Sekula";
        var clientPESEL = "12345678901";
        var clientEmail = "sekula.sebastian.kontakt@gmail.com";
        var clientPassword = "01234567890"; //TODO - LEPSZE HASLO
        var address = new Address("Poland", "Warszawa", "Grójecka", "39", "12-102");

        var identityCard = new IdentityCard("DOWÓD POLSKI", "RXA", "12121212", "Polska");

        var bankClient = new BankClient(
                clientNumber,
                accountNumber,
                balance,
                clientName,
                clientSurname,
                clientPESEL,
                clientEmail
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

        var bclientNumber = "2";
        var baccountNumber = "22345678901234567890123456";
        var bbalance = 1000.0m;
        var bclientName = "Bob";
        var bclientSurname = "Bobowski";
        var bclientPESEL = "22345678901";
        var bclientEmail = "bob@gmail.com";
        var bclientPassword = "01234567890"; //TODO - LEPSZE HASLO
        var baddress = new Address("Poland", "Warszawa", "Grójecka", "39", "12-102");

        var bidentityCard = new IdentityCard("DOWÓD POLSKI", "RXA", "22121212", "Polska");

        var bbankClient = new BankClient(
                bclientNumber,
                baccountNumber,
                bbalance,
                bclientName,
                bclientSurname,
                bclientPESEL,
                bclientEmail
            );

        bbankClient.AddressId = baddress.Id;
        bbankClient.IdentityCardId = bidentityCard.Id;

        baddress.BankClientId = bbankClient.Id;
        bidentityCard.BankClientId = bbankClient.Id;


        modelBuilder.Entity<BankClient>().HasData(
            bbankClient
        );

        modelBuilder.Entity<Address>().HasData(
            baddress
        );

        var bpartialPasswordList = _passwordManager.GenerateHashedPartialPasswords(bclientPassword);
        foreach(var pp in bpartialPasswordList)
        {
            pp.BankClientId = bbankClient.Id;
        }

        modelBuilder.Entity<PartialPassword>().HasData(
            bpartialPasswordList
        );

        modelBuilder.Entity<IdentityCard>().HasData(
            bidentityCard
        );
    }
}
