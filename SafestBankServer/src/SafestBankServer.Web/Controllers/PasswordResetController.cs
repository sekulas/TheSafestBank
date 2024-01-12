using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SafestBankServer.Application.Features.PasswordReset;
using SafestBankServer.Application.Features.PasswordReset.DTO;

namespace SafestBankServer.Web.Controllers;

[Route("api/password-reset")]
[ApiController]
[AllowAnonymous]
public class PasswordResetController : ControllerBase
{
    private readonly IPasswordResetService _passwordResetService;
    public PasswordResetController(IPasswordResetService passwordResetService)
    {
        _passwordResetService = passwordResetService;
    }

    [HttpPost]
    public async Task<ActionResult<int[]>> SendPasswordResetMailAsync([FromBody] SendPasswordResetMailDto sendPasswordResetMailDto)
    {
        await _passwordResetService.SendPasswordResetMailAsync(sendPasswordResetMailDto);
        return Ok();
    }

    [HttpPut]
    public async Task<ActionResult<int[]>> ResetPassword([FromBody] ResetPasswordDto resetPasswordDto)
    {
        await _passwordResetService.ResetPassword(resetPasswordDto);
        return Ok();
    }
}
