using SafestBankServer.Application.Features.PasswordReset.DTO;

namespace SafestBankServer.Application.Features.PasswordReset;
public interface IPasswordResetService
{
    Task SendPasswordResetMailAsync(SendPasswordResetMailDto sendPasswordResetDto);
    Task ResetPassword(ResetPasswordDto passwordResetDto);
}
