using Konscious.Security.Cryptography;
using SafestBankServer.Core.Auth.Passwords;
using System.Security.Cryptography;
using System.Text;

namespace SafestBankServer.Application.Auth.Passwords;

//TODO - PO ZASEEDOWANIU BAZY ZMIEN TO INTERNAL
public class PasswordManager : IPasswordManager
{
    private readonly SecurityOptions _securityOptions;
    public PasswordManager(SecurityOptions securityOptions)
    {
        _securityOptions = securityOptions;
    }

    public List<PartialPassword> GenerateHashedPartialPasswords(string password)
    {
        int passwordLength = password.Length;
        int partialPasswordLength = passwordLength / _securityOptions.PartialPasswordLengthDenominator;

        StringBuilder partialPasswordBuilder = new();

        while(true)
        {
            int[] wholePasswordWarden = new int[passwordLength];
            List<PartialPassword> partialPasswordList = new List<PartialPassword>();

            for(int i = 0; i < _securityOptions.AmoutOfPartialPasswords; i++)
            {
                int[] mask = new int[partialPasswordLength];
                bool[] maskWarden = new bool[passwordLength];
                partialPasswordBuilder.Clear();

                for(int j = 0; j < partialPasswordLength; j++)
                {

                    int index = GenerateRandomIndex(passwordLength);

                    while(maskWarden[index] == true)
                    {
                        index = GenerateRandomIndex(passwordLength);
                    }

                    mask[j] = index;
                    maskWarden[index] = true;
                    wholePasswordWarden[index]++;
                }

                mask = mask.OrderBy(x => x).ToArray();

                foreach(int index in mask)
                {
                    partialPasswordBuilder.Append(password[index]);
                }

                string partialPasswordString = partialPasswordBuilder.ToString();
                byte[] salt = GenerateSalt();

                var partialPassword = GenerateHashedPartialPassword(mask, salt, partialPasswordString);

                partialPasswordList.Add(partialPassword);
            }

            if(wholePasswordWarden.All(x => x > 0) && !CheckIfThereAreDuplicatedMasks(partialPasswordList))
            {
                partialPasswordList[0].PasswordStatus = PasswordStatus.HAS_TO_BE_USED;
                return partialPasswordList;
            }
        }
    }
    public bool VerifyPassword(string givenPassword, PartialPassword partialPassword)
    {
        var passwordToVerify = GenerateHashedPartialPassword(partialPassword.Mask, partialPassword.Salt, givenPassword);

        return passwordToVerify.PartialPasswordHash.SequenceEqual(partialPassword.PartialPasswordHash);
    }
    public int GenerateRandomIndex(int maxIndex)
    {
        byte[] byteIndex = new byte[4];

        using var rng = RandomNumberGenerator.Create();
        rng.GetBytes(byteIndex);

        int randomNumber = BitConverter.ToInt32(byteIndex, 0);
        int index = Math.Abs(randomNumber % maxIndex);

        return index;
    }
    private PartialPassword GenerateHashedPartialPassword(int[] mask, byte[] salt, string partialPassword)
    {
        byte[] partialPasswordBytes = Encoding.UTF8.GetBytes(partialPassword);
        byte[] hashedPartialPasswordBytes;

        using(var hasher = new Argon2id(partialPasswordBytes))
        {
            hasher.Salt = salt;
            hasher.DegreeOfParallelism = _securityOptions.DegreeOfParallelism;
            hasher.MemorySize = _securityOptions.MemorySize;
            hasher.Iterations = _securityOptions.Iterations;

            hashedPartialPasswordBytes = hasher.GetBytes(_securityOptions.HashSize);
        }

        return new PartialPassword(mask, salt, hashedPartialPasswordBytes);
    }
    private static bool CheckIfThereAreDuplicatedMasks(List<PartialPassword> partialPasswordList)
    {
        for(int i = 0; i < partialPasswordList.Count; i++)
        {
            for(int j = i + 1; j < partialPasswordList.Count; j++)
            {
                if(partialPasswordList[i].Mask.SequenceEqual(partialPasswordList[j].Mask))
                {
                    return true;
                }
            }
        }

        return false;
    }

    private byte[] GenerateSalt()
    {
        byte[] salt = new byte[_securityOptions.SaltSize];

        using var rng = RandomNumberGenerator.Create();
        rng.GetBytes(salt);

        return salt;
    }
}
