using Microsoft.EntityFrameworkCore;
using SafestBankServer.Core.Auth.Passwords;
using SafestBankServer.Core.Client;
using SafestBankServer.Infrastructure.EF.Contexts;

namespace SafestBankServer.Infrastructure.Auth;
internal sealed class ClientRepository : IClientRepository
{
    private readonly SafestBankDbContext _dbContext;

    public ClientRepository(SafestBankDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<BankClient?> GetClientByNumberAsync(string clientNumber)
    {
        var client = await _dbContext.BankClients
            .Include(x => x.IdentityCard)
            .Include(x => x.Address)
            .Include(x => x.PartialPasswords)
            .Where(x => x.ClientNumber == clientNumber)
            .FirstOrDefaultAsync();

        if(client == null)
        {
            return null;
        }

        return client;
    }

    public async Task UpdateClientAsync(BankClient client)
    {
        _dbContext.BankClients.Update(client);
        await _dbContext.SaveChangesAsync();
    }
}
