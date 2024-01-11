namespace SafestBankServer.Application.Features.Transaction.Transaction;
public class ClientTransactionDto
{
    public string SenderName { get; set; }
    public string SenderSurname { get; set; }
    public string SenderAccountNumber { get; set; }
    public string RecipientName { get; set; }
    public string RecipientSurname { get; set; }
    public string RecipientAccountNumber { get; set; }
    public decimal Amount { get; set; }
    public DateTime Time { get; set; }
    public string Title { get; set; }
}
