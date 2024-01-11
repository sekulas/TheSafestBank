using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SafestBankServer.Application.DTO.Transaction;
using SafestBankServer.Application.Transaction;
using SafestBankServer.Web.Configuration.Session;

namespace SafestBankServer.Web.Controllers;

[Route("api/transaction")]
[ApiController]
[Authorize]
public class TransactionController : ControllerBase
{
    private readonly ITransactionService _transactionService;
    private readonly SessionManager _sessionManager;
    public TransactionController(ITransactionService transactionService, SessionManager sessionManager)
    {
        _transactionService = transactionService;
        _sessionManager = sessionManager;
    }

    [HttpPost]
    public async Task<ActionResult<ClientTransactionDto>> MakeTransaction([FromBody] MakeTransactionDto transaction)
    {
        var clientId = await _sessionManager.GetClientId(HttpContext);
        await _sessionManager.RefreshSession(HttpContext);

        var transactionDto = 
            await _transactionService.MakeTransaction(clientId, transaction.RecipientAccountNumber, transaction.Amount, transaction.Title);

        return Ok(transactionDto);
    }
}
