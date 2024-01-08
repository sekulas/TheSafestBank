using System.ComponentModel.DataAnnotations;

namespace SafestBankServer.Application.DTO.Transaction;
public class MakeTransactionDto
{

    [RegularExpression(@"^[0-9]{26}")]
    public string RecipientAccountNumber { get; set; }

    [Range(0.01, 1000000000)]
    public decimal Amount { get; set; }

    [RegularExpression(@"^[a-zA-Z0-9 .-]{1,100}$")]
    public string Title { get; set; }
}