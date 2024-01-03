using SafestBankServer.Application.DTO.Transaction;

namespace SafestBankServer.Application.Transaction;
public interface ITransactionService
{
    Task<ClientTransactionDto> MakeTransaction(string senderNumber, string recipantAccountNumber, decimal amout, string title);
}
