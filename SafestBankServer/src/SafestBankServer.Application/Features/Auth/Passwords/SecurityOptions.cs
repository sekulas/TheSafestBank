namespace SafestBankServer.Application.Auth.Passwords;

internal record SecurityOptions
{
    public int AmoutOfPartialPasswords { get; } = 10;
    public int PartialPasswordLengthDenominator { get; } = 3;
    public int SaltSize { get; } = 16;
    public int DegreeOfParallelism { get; } = 1;
    public int MemorySize { get; } = 19456;
    public int Iterations { get; } = 2;
    public int HashSize { get; } = 32;
}
