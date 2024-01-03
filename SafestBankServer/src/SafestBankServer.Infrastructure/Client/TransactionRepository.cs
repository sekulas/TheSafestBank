using Microsoft.EntityFrameworkCore;
using SafestBankServer.Core.Transaction;
using SafestBankServer.Infrastructure.EF.Contexts;

namespace SafestBankServer.Infrastructure.Client;
internal sealed class TransactionRepository : ITransactionRepository
{
    private readonly SafestBankDbContext _dbContext;
    public TransactionRepository(SafestBankDbContext dbContext)
    {
         _dbContext = dbContext;
    }
    public async Task AddTransactionAsync(ClientTransaction transaction)
    {
        _dbContext.ClientTransactions.Add(transaction);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<IList<ClientTransaction>?> GetClientTransactions(Guid clientId)
    {
        try
        {
            var transactions = await _dbContext.ClientTransactions
                .Where(x => x.SenderId == clientId || x.RecipientId == clientId).OrderByDescending(x => x.Time).ToListAsync();

            return transactions;
        }
        catch
        {
            return null;
        }
    }
}
