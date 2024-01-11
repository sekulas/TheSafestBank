using Microsoft.EntityFrameworkCore;
using SafestBankServer.Core.Auth.Passwords;
using SafestBankServer.Core.Client;
using SafestBankServer.Core.Transaction;
using SafestBankServer.Infrastructure.EF.Contexts;

namespace SafestBankServer.Infrastructure.Auth;
internal sealed class ClientRepository : IClientRepository
{
    private readonly SafestBankDbContext _dbContext;
    private readonly ITransactionRepository _transactionRepository;

    public ClientRepository(SafestBankDbContext dbContext, ITransactionRepository transactionRepository)
    {
        _dbContext = dbContext;
        _transactionRepository = transactionRepository;
    }

    public async Task<BankClient?> GetClientByIdAsync(Guid clientId)
    {
        BankClient? client = null;
        try
        {
            client = await _dbContext.BankClients
                .Include(x => x.IdentityCard)
                .Include(x => x.Address)
                .Where(x => x.Id == clientId)
                .FirstOrDefaultAsync();
        }
        catch(Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

        if(client is null)
        {
            return null;
        }

        CheckIfClientIsBlocked(client);

        client.PartialPasswords = await _dbContext.PartialPasswords
            .Where(x => x.BankClientId == client.Id)
            .ToListAsync();

        client.Transactions = await _transactionRepository.GetClientTransactions(client.Id);

        return client;
    }

    public async Task<BankClient?> GetClientByClientNumberAsync(string clientNumber)
    {
        BankClient? client = null;
        try
        {
            client = await _dbContext.BankClients
                .Include(x => x.IdentityCard)
                .Include(x => x.Address)
                .Where(x => x.ClientNumber == clientNumber)
                .FirstOrDefaultAsync();
        }
        catch(Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

        if(client is null)
        {
            return null;
        }

        CheckIfClientIsBlocked(client);

        client.PartialPasswords = await _dbContext.PartialPasswords
            .Where(x => x.BankClientId == client.Id)
            .ToListAsync();

        client.Transactions = await _transactionRepository.GetClientTransactions(client.Id);

        return client;
    }

    public async Task<BankClient?> GetClientByAccountNumberAsync(string accountNumber)
    {
        BankClient? client = null;

        try
        {
            client = await _dbContext.BankClients
                .Include(x => x.IdentityCard)
                .Include(x => x.Address)
                .Where(x => x.AccountNumber == accountNumber)
                .FirstOrDefaultAsync();
        }
        catch(Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

        if(client is null)
        {
            return null;
        }

        CheckIfClientIsBlocked(client);

        client.PartialPasswords = await _dbContext.PartialPasswords
            .Where(x => x.BankClientId == client.Id)
            .ToListAsync();

        client.Transactions = await _transactionRepository.GetClientTransactions(client.Id);

        return client;
    }

    public async Task UpdateClientAsync(BankClient client)
    {
        _dbContext.BankClients.Update(client);
        await _dbContext.SaveChangesAsync();
    }
    public async Task UpdateClientPasswords(BankClient client, List<PartialPassword> partialPasswords)
    {
        foreach(var pp in client.PartialPasswords)
        {
            _dbContext.PartialPasswords.Remove(pp);
        }
        await _dbContext.SaveChangesAsync();
        foreach(var pp in partialPasswords)
        {
            pp.BankClientId = client.Id;
        }
        _dbContext.PartialPasswords.AddRange(partialPasswords);
        await _dbContext.SaveChangesAsync();
    }
    public Task<bool> IsTokenGeneratingColisions(byte[] hashedToken)
    {
        bool result = _dbContext.BankClients.Where(bc => bc.PasswordResetTokenHash == hashedToken).Any();
        return Task.FromResult(result);
    }
    public async Task<BankClient?> GetClientByHashedToken(byte[] hashedToken)
    {
        BankClient? client = null;
        try
        {
             client = await _dbContext.BankClients
                .Where(bc => bc.PasswordResetTokenHash == hashedToken)
                .FirstOrDefaultAsync();
        }
        catch(Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

        if(client is null)
        {
            return null;
        }

        CheckIfClientIsBlocked(client);

        client.PartialPasswords = await _dbContext.PartialPasswords
            .Where(x => x.BankClientId == client.Id)
            .ToListAsync();

        return client;
    }
    private void CheckIfClientIsBlocked(BankClient client)
    {
        if(client.IsBlocked)
        {
            throw new UnauthorizedAccessException("Your account has been blocked. Please contact with the support.");
        }
    }
}
