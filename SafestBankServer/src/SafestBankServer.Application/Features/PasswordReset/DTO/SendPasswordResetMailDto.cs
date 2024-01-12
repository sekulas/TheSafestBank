namespace SafestBankServer.Application.Features.PasswordReset.DTO;
public class SendPasswordResetMailDto
{
    //TODO: zmiana ilosci znakow
    //[RegularExpression(@"^[0-9]{1}")]
    public string ClientNumber { get; set; }

    //[RegularExpression(@"^[a-zA-Z0-9_+&*-]+(?:\\.[a-zA-Z0-9_+&*-]+)*@(?:[a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,}$")]
    public string Email { get; set; }
}
