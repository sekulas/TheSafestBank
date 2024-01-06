using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Extensions.Caching.Memory;
using System.Security.Claims;

namespace SafestBankServer.Web.Configuration.CookieAuth;

public class CustomCookieAuthenticationEvents : CookieAuthenticationEvents
{
    private readonly IMemoryCache _cache;
    private readonly CookieAuthOptions _cookieAuthOptions;
    public CustomCookieAuthenticationEvents(IMemoryCache cache, CookieAuthOptions cookieAuthOptions)
    {
        _cache = cache;
        _cookieAuthOptions = cookieAuthOptions;
    }

    public override async Task ValidatePrincipal(CookieValidatePrincipalContext context)
    {
        var principal = context.Principal;
        var sid = principal.Claims.FirstOrDefault(c => c.Type == "id")?.Value;

        if (sid == null)
        {
            context.RejectPrincipal();
            return;
        }

        if(!_cache.TryGetValue(sid, out string? clientNumber))
        {
            context.RejectPrincipal();
            return;
        }

        if (clientNumber is null)
        {
            context.RejectPrincipal();
            return;
        }

        //TODO GENERATE NEW SESSION ID

        _cache.Set(sid, clientNumber, _cookieAuthOptions.CookieExpirationTime);

        await Task.CompletedTask;
    }
}
