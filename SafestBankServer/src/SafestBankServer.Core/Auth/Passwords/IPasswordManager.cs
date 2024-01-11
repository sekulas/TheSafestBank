namespace SafestBankServer.Core.Auth.Passwords;
public interface IPasswordManager
{
    List<PartialPassword> GenerateHashedPartialPasswords(string password);
    bool VerifyPassword(string givenPassword, PartialPassword partialPassword);
    int GenerateRandomIndex(int maxIndex);
}
