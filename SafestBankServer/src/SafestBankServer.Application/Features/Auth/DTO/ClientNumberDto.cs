using System.ComponentModel.DataAnnotations;

namespace SafestBankServer.Application.Features.Auth.DTO;

public class ClientNumberDto
{
    [Required]
    [RegularExpression(@"^[0-9]{1,24}$")]
    public string ClientNumber { get; set; }
}
