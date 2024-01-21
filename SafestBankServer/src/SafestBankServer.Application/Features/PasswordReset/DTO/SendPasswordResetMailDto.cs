using System.ComponentModel.DataAnnotations;

namespace SafestBankServer.Application.Features.PasswordReset.DTO;
public class SendPasswordResetMailDto
{
    [Required]
    [RegularExpression(@"^[0-9]{1,24}$")]
    public string ClientNumber { get; set; }

    [Required]
    [RegularExpression(@"^[a-zA-Z0-9_+&*-]{1,64}(?:\.[a-zA-Z0-9_+&*-]{1,64})*@(?:[a-zA-Z0-9-]+\.){1,64}[a-zA-Z]{1,64}$")]
    public string Email { get; set; }
}
