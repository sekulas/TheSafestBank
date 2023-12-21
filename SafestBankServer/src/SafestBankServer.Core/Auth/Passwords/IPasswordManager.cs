namespace SafestBankServer.Core.Auth.Passwords;
public interface IPasswordManager
{
    IList<PartialPassword> GenerateHashedPartialPasswords(string password);
    bool VerifyPassword(string givenPassword, PartialPassword partialPassword);
    int GenerateRandomIndex(int maxIndex);
}
