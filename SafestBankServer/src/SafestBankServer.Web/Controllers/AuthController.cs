using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using SafestBankServer.Application.Auth;
using SafestBankServer.Application.DTO.Auth;
using SafestBankServer.Web.Configuration.CookieAuth;
using System.Security.Claims;

namespace SafestBankServer.Web.Auth;

[Route("api/auth")]
[ApiController]
[Authorize]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;
    private readonly IMemoryCache _cache;
    private readonly CookieAuthOptions _cookieAuthOptions;
    public AuthController(IAuthService authRepository, IMemoryCache cache, CookieAuthOptions cookieAuthOptions)
    {
        _authService = authRepository;
        _cache = cache;
        _cookieAuthOptions = cookieAuthOptions;
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
        await _authService.LoginAsync(clientLoginDto);
        await GenerateSessionForUser(clientLoginDto.ClientNumber);

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
        await HttpContext.SignOutAsync("Session");

        return Ok();
    }

    private async Task GenerateSessionForUser(string clientNumber)
    {
        //TODO - GENERATE SESSION ID IN A BETTER WAY
        //COOKIE TIMESPAN
        var claim = new Claim("id", Guid.NewGuid().ToString());
        await SignInUserAsync(claim);
        CacheUserId(claim.Value, clientNumber, _cookieAuthOptions.CookieExpirationTime);
    }

    private async Task SignInUserAsync(Claim claim)
    {
        var claimsIdentity = new ClaimsIdentity(new[] { claim }, "Session");
        var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

        await HttpContext.SignInAsync("Session", claimsPrincipal);
    }

    private void CacheUserId(string sessionId, string clientNumber, TimeSpan expirationTime)
    {
        _cache.Set(sessionId, clientNumber, expirationTime);
    }
}