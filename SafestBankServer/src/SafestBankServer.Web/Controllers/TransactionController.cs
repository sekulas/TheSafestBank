using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using SafestBankServer.Application.DTO.Transaction;
using SafestBankServer.Application.Transaction;

namespace SafestBankServer.Web.Controllers;

[Route("api/transaction")]
[ApiController]
[Authorize]
public class TransactionController : ControllerBase
{
    private readonly IMemoryCache _cache;
    private readonly ITransactionService _transactionService;
    public TransactionController(IMemoryCache cache, ITransactionService transactionService)
    {
        _cache = cache;
        _transactionService = transactionService;
    }

    [HttpPost]
    public async Task<ActionResult<ClientTransactionDto>> MakeTransaction([FromBody] MakeTransactionDto transaction)
    {
        var sid = HttpContext.User.Claims.FirstOrDefault(c => c.Type == "id")?.Value
            ?? throw new UnauthorizedAccessException("Your session has expired - please log in.");

        var clientNumber = _cache.Get<string>(sid)
            ?? throw new UnauthorizedAccessException("Your session has expired - please log in.");

        var transactionDto = 
            await _transactionService.MakeTransaction(clientNumber, transaction.RecipientAccountNumber, transaction.Amount, transaction.Title);

        return Ok(transactionDto);
    }
}
