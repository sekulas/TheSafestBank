using SafestBankServer.Application.DTO.Transaction;

namespace SafestBankServer.Application.Transaction;
public interface ITransactionService
{
    Task<ClientTransactionDto> MakeTransaction(Guid senderId, string recipantAccountNumber, decimal amout, string title);
}
