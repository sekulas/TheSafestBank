using System.ComponentModel.DataAnnotations;

namespace SafestBankServer.Application.Features.Transaction.Transaction;
public class MakeTransactionDto
{
    [Required]
    [RegularExpression(@"^[0-9]{26}$")]
    public string RecipientAccountNumber { get; set; }

    [Required]
    [Range(0.01, 1000000000)]
    public decimal Amount { get; set; }

    [Required]
    [RegularExpression(@"^[a-zA-Z0-9 .-]{1,256}$")]
    public string Title { get; set; }
}