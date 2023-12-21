namespace SafestBankServer.Core.Client.Data;
public class IdentityCard
{
    public Guid Id { get; protected set; } = Guid.NewGuid();
    public string Type { get; protected set; }
    public string Serie { get; protected set; }
    public string Number { get; protected set; }
    public string CountryOfIssue { get; protected set; }
    public Guid BankClientId { get; set; }

    public IdentityCard(string type, string serie, string number, string countryOfIssue)
    {
        Type = type;
        Serie = serie;
        Number = number;
        CountryOfIssue = countryOfIssue;
    }
}
