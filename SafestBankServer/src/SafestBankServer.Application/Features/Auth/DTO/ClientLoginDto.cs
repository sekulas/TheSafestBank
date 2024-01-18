using System.ComponentModel.DataAnnotations;

namespace SafestBankServer.Application.Features.Auth.DTO;

public class ClientLoginDto
{
    //TODO - zmien odpowiednio ilosc znakow
    [Required]
    [RegularExpression(@"^[0-9]{1}$")]
    public string ClientNumber { get; set; }

    [Required]
    [RegularExpression(@"^[a-zA-Z\d!@#$%^&*()\-_+. ]{1,64}$")]
    public string Password { get; set; }
}
