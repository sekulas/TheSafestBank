namespace SafestBankServer.Application.DTO.PasswordReset;
public class ResetPasswordDto
{
    //TODO: ADD REGEX
    public string Password { get; set; }

    public string ConfirmPassword { get; set; }

    public string Token { get; set; }
}