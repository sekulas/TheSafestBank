using System.ComponentModel.DataAnnotations;

namespace SafestBankServer.Application.Features.PasswordReset.DTO;
public class ResetPasswordDto
{
    [Required]
    [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z].*[A-Z])(?=.*\d.*\d)(?=.*[!@#$%^&*()\-_+. ])[a-zA-Z\d!@#$%^&*()\-_+. ]{16,64}$")]
    public string Password { get; set; }

    [Required]
    [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z].*[A-Z])(?=.*\d.*\d)(?=.*[!@#$%^&*()\-_+. ])[a-zA-Z\d!@#$%^&*()\-_+. ]{16,64}$")]
    [Compare("Password")]
    public string ConfirmPassword { get; set; }

    [Required]
    public string Token { get; set; }
}