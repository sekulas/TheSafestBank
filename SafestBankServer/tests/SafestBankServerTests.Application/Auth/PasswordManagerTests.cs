/*
using SafestBankServer.Application.Auth.Passwords;
using SafestBankServer.Core.Auth.Passwords;
using System.Text;

namespace SafestBankServerTests.Application.Auth;
public class PasswordManagerTests
{
    private readonly SecurityOptions _securityOptions;
    private readonly PasswordManager _passwordManager;
    public PasswordManagerTests()
    {
        _securityOptions = new SecurityOptions();
        _passwordManager = new PasswordManager(_securityOptions);
    }

    [Fact]
    public void GenerateHashedPartialPasswords_ShouldReturnListOfPartialPasswords()
    {
        // Arrange
        var password = "ToJestNaprawdeDobreHaslo123";

        // Act
        var result = _passwordManager.GenerateHashedPartialPasswords(password);

        // Assert
        result.Should().NotBeNull();
        result.Count.Should().Be(_securityOptions.AmoutOfPartialPasswords);
    }

    [Fact]
    public void VerifyPassword_SchouldBeAbleToVerifyAllThePasswords()
    {
        // Arrange
        var password = "ToJestNaprawdeDobreHaslo123";
        var partialPasswordList = _passwordManager.GenerateHashedPartialPasswords(password);
        StringBuilder partialPasswordBuilder = new();

        // Act
        foreach(var partialPassword in partialPasswordList)
        {
            partialPasswordBuilder.Clear();

            foreach(var index in partialPassword.Mask)
            {
                partialPasswordBuilder.Append(password[index]);
            }

            var result = _passwordManager.VerifyPassword(partialPasswordBuilder.ToString(), partialPassword);

            // Assert
            result.Should().BeTrue();
        }
    }
}
*/