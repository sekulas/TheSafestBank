using SafestBankServer.Core.Client;

namespace SafestBankServer.Core.Transaction;
public class ClientTransaction
{
    public Guid Id { get; protected set; } = Guid.NewGuid();
    public Guid SenderId { get; protected set; }
    public string SenderName { get; protected set; }
    public string SenderSurname { get; protected set; }
    public string SenderAccountNumber { get; protected set; }
    public Guid RecipientId { get; protected set; }
    public string RecipientName { get; protected set; }
    public string RecipientSurname { get; protected set; }
    public string RecipientAccountNumber { get; protected set; }
    public decimal Amount { get; protected set; }
    public DateTime Time { get; protected set; }
    public string Title { get; protected set; }

    public ClientTransaction(
        Guid senderId, 
        string senderName, 
        string senderSurname, 
        string senderAccountNumber, 
        Guid recipientId, 
        string recipientName, 
        string recipientSurname, 
        string recipientAccountNumber, 
        decimal amount, 
        DateTime time, 
        string title)
    {
        SenderId = senderId;
        SenderName = senderName;
        SenderSurname = senderSurname;
        SenderAccountNumber = senderAccountNumber;
        RecipientId = recipientId;
        RecipientName = recipientName;
        RecipientSurname = recipientSurname;
        RecipientAccountNumber = recipientAccountNumber;
        Amount = amount;
        Time = time;
        Title = title;
    }
}
