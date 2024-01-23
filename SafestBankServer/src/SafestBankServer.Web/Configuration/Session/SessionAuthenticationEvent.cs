using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Extensions.Caching.Memory;

namespace SafestBankServer.Web.Configuration.CookieAuth;

internal class SessionAuthenticationEvent : CookieAuthenticationEvents
{
    private readonly IMemoryCache _cache;
    public SessionAuthenticationEvent(IMemoryCache cache)
    {
        _cache = cache;
    }

    public override async Task ValidatePrincipal(CookieValidatePrincipalContext context)
    {
        var principal = context.Principal;

        if (principal == null)
        {
            context.RejectPrincipal();
            return;
        }

        if(!Guid.TryParse(principal.Claims.FirstOrDefault(c => c.Type == "id")?.Value, out Guid sid))
        {
            context.RejectPrincipal();
        }

        if(!_cache.TryGetValue(sid.ToString(), out string? clientNumber))
        {
            context.RejectPrincipal();
            return;
        }

        if (clientNumber is null)
        {
            context.RejectPrincipal();
            return;
        }

        await Task.CompletedTask;
    }
}
