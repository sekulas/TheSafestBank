using System.ComponentModel.DataAnnotations;

namespace SafestBankServer.Application.Features.Auth.DTO;

public class ClientNumberDto
{
    //TODO - zmien odpowiednio ilosc znakow
    [Required]
    [RegularExpression(@"^[0-9]{1}$")]
    public string ClientNumber { get; set; }
}
