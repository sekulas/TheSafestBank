using SafestBankServer.Application.Features.Transaction.Transaction;

namespace SafestBankServer.Application.Features.Transaction;
public interface ITransactionService
{
    Task<ClientTransactionDto> MakeTransaction(Guid senderId, string recipantAccountNumber, decimal amout, string title);
}
