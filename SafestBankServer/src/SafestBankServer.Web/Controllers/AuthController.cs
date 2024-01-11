using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SafestBankServer.Application.Auth;
using SafestBankServer.Application.DTO.Auth;
using SafestBankServer.Web.Configuration.Session;

namespace SafestBankServer.Web.Auth;

[Route("api/auth")]
[ApiController]
[Authorize]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;
    private readonly SessionManager _sessionManager;
    public AuthController(IAuthService authRepository, SessionManager sessionManager)
    {
        _authService = authRepository;
        _sessionManager = sessionManager;
    }

    [AllowAnonymous]
    [HttpPost("password")]
    public async Task<ActionResult<int[]>> GetPasswordMaskAsync([FromBody] ClientNumberDto clientNumberDto)
    {
        var passwordMask = await _authService.GetPasswordMaskAsync(clientNumberDto);
        return Ok(passwordMask);
    }

    [AllowAnonymous]
    [HttpPost("login")]
    public async Task<ActionResult> LoginAsync([FromBody] ClientLoginDto clientLoginDto)
    {
        var clientId = await _authService.LoginAsync(clientLoginDto);
        await _sessionManager.GenerateSession(HttpContext, clientId);

        return Ok();
    }

    [AllowAnonymous]
    [HttpGet("login")]
    public Task UnauthorizedAccess()
    {
        throw new UnauthorizedAccessException("Your session has expired - please log in.");
    }

    [HttpPost("logout")]
    public async Task<ActionResult> LogoutAsync()
    {
        await _sessionManager.EndSession(HttpContext);

        return Ok();
    }
}