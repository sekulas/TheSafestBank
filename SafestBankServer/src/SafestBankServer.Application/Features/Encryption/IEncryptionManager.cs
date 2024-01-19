namespace SafestBankServer.Application.Features.Encryption;
public interface IEncryptionManager
{
    byte[] GenerateIV();
    string Encrypt(string client, byte[] iv);
    string Decrypt(string client, byte[] iv);
}
