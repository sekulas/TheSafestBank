using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System.Security.Claims;

namespace SafestBankServer.Web.Controllers;

[Route("api/client")]
[ApiController]
[Authorize(Policy="SessionPolicy")]
public class BankClientController : ControllerBase
{
    private readonly IMemoryCache _cache;
    public BankClientController(IMemoryCache cache)
    {
         _cache = cache;
    }

    [HttpGet]
    public async Task<ActionResult<string>> GetClient()
    {
        var sid = HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Sid)?.Value;
        var client = _cache.Get(sid);

        var data = new { message = client };
        return Ok(data);
    }
}
