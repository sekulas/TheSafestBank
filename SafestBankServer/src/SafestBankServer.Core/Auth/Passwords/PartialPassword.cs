namespace SafestBankServer.Core.Auth.Passwords;
public class PartialPassword
{
    public Guid Id { get; protected set; }
    public int[] Mask { get; protected set; }
    public byte[] Salt { get; protected set; }
    public byte[] PartialPasswordHash { get; protected set; }
    public PasswordStatus PasswordStatus { get; set; }
    public Guid BankClientId { get; set; }
    public PartialPassword(int[] mask, byte[] salt, byte[] partialPasswordHash)
    {
        Id = Guid.NewGuid();
        Mask = mask;
        Salt = salt;
        PartialPasswordHash = partialPasswordHash;
        PasswordStatus = PasswordStatus.NOT_USED;
    }
}
