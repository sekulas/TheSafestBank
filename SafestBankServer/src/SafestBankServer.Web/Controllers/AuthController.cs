using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using SafestBankServer.Application.Auth;
using SafestBankServer.Application.DTO.Auth;
using SafestBankServer.Application.DTO.Client;
using System.Security.Claims;

namespace SafestBankServer.Web.Auth;

[Route("api/auth")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;
    public AuthController(IAuthService authRepository)
    {
        _authService = authRepository;
    }

    [HttpPost("password")]
    public async Task<ActionResult<int[]>> GetPasswordMaskAsync([FromBody] ClientNumberDto clientNumberDto)
    {
        var passwordMask = await _authService.GetPasswordMaskAsync(clientNumberDto);
        return Ok(passwordMask);
    }

    [HttpPost("login")]
    public async Task<ActionResult<BankClientDto>> LoginAsync([FromBody] ClientLoginDto clientLoginDto)
    {
        var result = await _authService.LoginAsync(clientLoginDto);
        await HttpContext.SignInAsync("Session", 
            new ClaimsPrincipal
            (
                new ClaimsIdentity
                (
                    new Claim[] 
                    { 
                        new Claim(ClaimTypes.Sid, Guid.NewGuid().ToString())
                    }, 
                    "Session"
                )
            ),
            new AuthenticationProperties
            {
                IsPersistent = true,
            }
        );

        return Ok(result);
    }

    [HttpPost("logout")]
    public async Task<ActionResult> LogoutAsync()
    {
        await HttpContext.SignOutAsync("Session",
            new AuthenticationProperties
            {
                IsPersistent = true,
            }
        );

        return Ok();
    }
}