using SafestBankServer.Application.DTO.PasswordReset;

namespace SafestBankServer.Application.PasswordReset;
public interface IPasswordResetService
{
    Task SendPasswordResetMailAsync(SendPasswordResetMailDto sendPasswordResetDto);
    Task ResetPassword(ResetPasswordDto passwordResetDto);
}
