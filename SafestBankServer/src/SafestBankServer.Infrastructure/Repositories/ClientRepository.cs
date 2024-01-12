using Microsoft.EntityFrameworkCore;
using SafestBankServer.Application.Exceptions;
using SafestBankServer.Application.Exceptions.Auth;
using SafestBankServer.Application.Exceptions.Transaction;
using SafestBankServer.Core.Auth.Passwords;
using SafestBankServer.Core.Client;
using SafestBankServer.Core.Transaction;
using SafestBankServer.Infrastructure.EF.Contexts;

namespace SafestBankServer.Infrastructure.Repositories;
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
        try
        {
            var client = await _dbContext.BankClients
                .Include(x => x.IdentityCard)
                .Include(x => x.Address)
                .Where(x => x.Id == clientId)
                .FirstOrDefaultAsync()
                ?? throw new BankClientNotFoundException("Client with given id doesn't exist.");

            client.Transactions = await _transactionRepository.GetClientTransactions(client.Id)
                ?? throw new DatabaseException("Couldn't get client transactions.");

            return client;
        }
        catch(Exception ex)
        {
            Console.WriteLine(ex.Message);
            return null;
        }
    }

    public async Task<BankClient?> GetClientByClientNumberAsync(string clientNumber)
    {
        try
        {
            var client = await _dbContext.BankClients
                .Where(x => x.ClientNumber == clientNumber)
                .FirstOrDefaultAsync()
                ?? throw new BankClientNotFoundException("Client with given client number doesn't exist.");

            client.PartialPasswords = await GetClientPartialPasswords(client.Id)
                ?? throw new DatabaseException("Couldn't get client partial passwords.");

            return client;
        }
        catch(Exception ex)
        {
            Console.WriteLine(ex.Message);
            return null;
        }
    }

    public async Task<BankClient?> GetClientByAccountNumberAsync(string accountNumber)
    {
        try
        {
            var client = await _dbContext.BankClients
                .Where(x => x.AccountNumber == accountNumber)
                .FirstOrDefaultAsync()
                ?? throw new BankClientNotFoundException("Client with given account number doesn't exist.");

            return client;
        }
        catch(Exception ex)
        {
            Console.WriteLine(ex.Message);
            return null;
        }
    }
    public async Task<BankClient?> GetClientByHashedToken(byte[] hashedToken)
    {
        try
        {
            var client = await _dbContext.BankClients
                .Where(bc => bc.PasswordResetTokenHash == hashedToken)
                .FirstOrDefaultAsync()
                ?? throw new BankClientNotFoundException("Client with given token doesn't exist.");


            client.PartialPasswords = await GetClientPartialPasswords(client.Id)
                ?? throw new DatabaseException("Couldn't get client partial passwords.");

            return client;
        }
        catch(Exception ex)
        {
            Console.WriteLine(ex.Message);
            return null;
        }
    }
    public async Task UpdateClientAsync(BankClient client)
    {
        try
        {
            _dbContext.BankClients.Update(client);
            await _dbContext.SaveChangesAsync();
        }
        catch(Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    public async Task UpdateClientPasswords(BankClient client, List<PartialPassword> partialPasswords)
    {
        try
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
        catch(Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
    public Task<bool> IsTokenGeneratingColisions(byte[] hashedToken)
    {
        try
        {
            var result = _dbContext.BankClients.Where(bc => bc.PasswordResetTokenHash == hashedToken).Any();
            return Task.FromResult(result);
        }
        catch(Exception ex)
        {
            Console.WriteLine(ex.Message);
            return Task.FromResult(true);
        }
    }

    private async Task<List<PartialPassword>?> GetClientPartialPasswords(Guid clientId)
    {
        var partialPasswords = await _dbContext.PartialPasswords
            .Where(x => x.BankClientId == clientId)
            .ToListAsync();
        return partialPasswords;
    }
}
