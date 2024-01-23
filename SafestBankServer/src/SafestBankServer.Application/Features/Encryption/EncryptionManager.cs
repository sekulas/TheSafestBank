using System.Security.Cryptography;
using System.Text;

namespace SafestBankServer.Application.Features.Encryption;

internal class EncryptionManager : IEncryptionManager
{
    private readonly byte[] _encryptionKey;
    public EncryptionManager(string? key = null)
    {
        if(key == null)
        {
            _encryptionKey = Encoding.ASCII.GetBytes(Environment.GetEnvironmentVariable("KEY")!);
        }
        else
        {
            _encryptionKey = Encoding.ASCII.GetBytes(key);
        }
    }

    public byte[] GenerateIV()
    {
        using var rng = RandomNumberGenerator.Create();
        byte[] iv = new byte[16];

        rng.GetBytes(iv);

        return iv;
    }

    public string Encrypt(string plaintext, byte[] iv)
    {
        byte[] cyphertextBytes;
        using var aes = Aes.Create();

        var encryptor = aes.CreateEncryptor(_encryptionKey, iv);

        using(var memoryStream = new MemoryStream())
        {
            using(var cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
            {
                using(var streamWriter = new StreamWriter(cryptoStream))
                {
                    streamWriter.Write(plaintext);
                }
            }
            cyphertextBytes = memoryStream.ToArray();
        }

        var ciphertext = Convert.ToBase64String(cyphertextBytes);

        return ciphertext;
    }

    public string Decrypt(string cyphertext, byte[] iv)
    {
        var cyphertextBytes = Convert.FromBase64String(cyphertext);
        using var aes = Aes.Create();

        var decryptor = aes.CreateDecryptor(_encryptionKey, iv);

        string plaintext;

        using(var memoryStream = new MemoryStream(cyphertextBytes))
        {
            using(var cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read))
            {
                using(var streamReader = new StreamReader(cryptoStream))
                {
                    plaintext = streamReader.ReadToEnd();
                }
            }
        }

        return plaintext;
    }
}
