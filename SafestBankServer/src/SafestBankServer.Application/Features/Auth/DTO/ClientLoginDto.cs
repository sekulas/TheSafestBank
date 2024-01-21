using System.ComponentModel.DataAnnotations;

namespace SafestBankServer.Application.Features.Auth.DTO;

public class ClientLoginDto
{
    [Required]
    [RegularExpression(@"^[0-9]{1,12}$")]
    public string ClientNumber { get; set; }

    [Required]
    [RegularExpression(@"^[a-zA-Z\d!@#$%^&*()\-_+. ]{4,64}$")]
    public string Password { get; set; }
}
