using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using SafestBankServer.Application.Client;
using SafestBankServer.Application.DTO.Client;
using System.Security.Claims;

namespace SafestBankServer.Web.Controllers;

[Route("api/client")]
[ApiController]
[Authorize(Policy="SessionPolicy")]
public class ClientController : ControllerBase
{
    private readonly IMemoryCache _cache;
    private readonly IClientService _clientService;
    public ClientController(IMemoryCache cache, IClientService clientService)
    {
         _cache = cache;
        _clientService = clientService;
    }

    [HttpGet]
    public async Task<ActionResult<BankClientDto>> GetClient()
    {
        var sid = HttpContext.User.Claims.FirstOrDefault(c => c.Type == "id")?.Value
            ?? throw new UnauthorizedAccessException("Your session has expired - please log in.");

        var clientNumber = _cache.Get<string>(sid)
            ?? throw new UnauthorizedAccessException("Your session has expired - please log in.");

        var result = await _clientService.GetClientAsync(clientNumber);

        return Ok(result);
    }
}
