using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SafestBankServer.Web.Controllers;

[Route("api/client")]
[ApiController]
[Authorize(Policy="SessionPolicy")]
public class BankClientController : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<string>> GetClient()
    {
        var data = new { message = "YAS!" };
        return Ok(data);
    }
}
