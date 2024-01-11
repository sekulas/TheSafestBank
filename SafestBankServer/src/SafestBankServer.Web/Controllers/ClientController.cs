using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SafestBankServer.Application.Client;
using SafestBankServer.Application.DTO.Client;
using SafestBankServer.Web.Configuration.Session;

namespace SafestBankServer.Web.Controllers;

[Route("api/client")]
[ApiController]
[Authorize]
public class ClientController : ControllerBase
{
    private readonly IClientService _clientService;
    private readonly SessionManager _sessionManager;
    public ClientController(IClientService clientService, SessionManager sessionManager)
    {
        _clientService = clientService;
        _sessionManager = sessionManager;
    }

    [HttpGet]
    public async Task<ActionResult<BankClientDto>> GetClient()
    {
        var clientId = await _sessionManager.GetClientId(HttpContext);
        await _sessionManager.RefreshSession(HttpContext);

        var result = await _clientService.GetClientAsync(clientId);

        return Ok(result);
    }
}
