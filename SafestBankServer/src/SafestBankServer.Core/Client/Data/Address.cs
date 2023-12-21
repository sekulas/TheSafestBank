namespace SafestBankServer.Core.Client.Data;
public class Address
{
    public Guid Id { get; protected set; } = Guid.NewGuid();
    public string Country { get; protected set; }
    public string City { get; protected set; }
    public string Street { get; protected set; }
    public string HouseNumber { get; protected set; }
    public string ZipCode { get; protected set; }
    public Guid BankClientId { get; set; }

    public Address(string country, string city, string street, string houseNumber, string zipCode)
    {
        Country = country;
        City = city;
        Street = street;
        HouseNumber = houseNumber;
        ZipCode = zipCode;
    }
}
