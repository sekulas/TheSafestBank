using SafestBankServer.Application.Features.Encryption;

namespace SafestBankServerTests.Application.Encryption;
public class EncryptionManagerTests
{
    [Fact]
    public void Encryption_Decryption_SchouldResultWithTheSameString()
    {
        // Arrange
        var encryptionManager = new EncryptionManager();
        var iv = encryptionManager.GenerateIV();
        var testString = "test";

        // Act
        var encryptedString = encryptionManager.Encrypt(testString, iv);

        // Assert
        var decryptedString = encryptionManager.Decrypt(encryptedString, iv);

        decryptedString.Should().Be(testString);
    }
}
