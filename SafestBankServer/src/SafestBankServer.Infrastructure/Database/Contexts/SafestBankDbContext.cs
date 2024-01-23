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
    }
}
