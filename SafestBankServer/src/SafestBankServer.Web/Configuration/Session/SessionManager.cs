using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Caching.Memory;
using System.Security.Claims;

namespace SafestBankServer.Web.Configuration.Session;

public class SessionManager
{
    private readonly IMemoryCache _cache;
    private readonly SessionConfiguration _sessionConfiguration;
    public SessionManager(IMemoryCache cache, SessionConfiguration sessionConfiguration)
    {
        _cache = cache;
        _sessionConfiguration = sessionConfiguration;
    }
    public async Task GenerateSession(HttpContext httpContext, Guid clientId)
    {
        bool isSessionIdBeingUsed = true;
        var sessionId = "";

        while(isSessionIdBeingUsed)
        {
            sessionId = Guid.NewGuid().ToString();
            isSessionIdBeingUsed = _cache.TryGetValue(sessionId, out _);
        }

        await SignInUserAsync(sessionId, httpContext);

        CacheUserId(sessionId, clientId.ToString(), _sessionConfiguration.SessionExpirationTime);
    }
    public async Task RefreshSession(HttpContext httpContext)
    {
        var clientId = await GetClientId(httpContext);
        await EndSession(httpContext);
        await GenerateSession(httpContext, clientId);
    }
    public async Task EndSession(HttpContext httpContext)
    {
        var sessionId = GetClientId(httpContext).ToString();
        if(sessionId != null)
        {
            _cache.Remove(sessionId);
        }
        await httpContext.SignOutAsync("Session");
    }

    public Task<Guid> GetClientId(HttpContext httpContext)
    {
        var sessionId = httpContext.User.Claims.FirstOrDefault(c => c.Type == "id")?.Value;

        if(sessionId == null)
        {
            throw new UnauthorizedAccessException("Your session has expired - please log in.");
        }

        if (!_cache.TryGetValue(sessionId, out string? clientNumber))
        {
            throw new UnauthorizedAccessException("Your session has expired - please log in.");
        }

        if (clientNumber is null)
        {
            throw new UnauthorizedAccessException("Your session has expired - please log in.");
        }

        return Task.FromResult(Guid.Parse(clientNumber));
    }

    private async Task SignInUserAsync(string sessionId, HttpContext httpContext)
    {
        var claim = new Claim("id", sessionId);
        var claimsIdentity = new ClaimsIdentity(new[] { claim }, "Session");
        var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

        await httpContext.SignInAsync("Session", claimsPrincipal);
    }

    private void CacheUserId(string sessionId, string clientNumber, TimeSpan expirationTime)
    {
        _cache.Set(sessionId, clientNumber, expirationTime);
    }
}