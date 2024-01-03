using System.ComponentModel.DataAnnotations;

namespace SafestBankServer.Application.DTO.Transaction;
public class MakeTransactionDto
{
    public string RecipientAccountNumber { get; set; }
    public decimal Amount { get; set; }
    public string Title { get; set; }
}