namespace SafestBankServer.Core.Client.Data;
public class Address
{
    public Guid Id { get; protected set; } = Guid.NewGuid();
    public string Country { get; protected set; }
    public string City { get; set; }
    public string Street { get; set; }
    public string HouseNumber { get; set; }
    public string ZipCode { get; set; }
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
