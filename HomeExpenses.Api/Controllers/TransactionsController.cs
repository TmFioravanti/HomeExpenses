using HomeExpenses.Api.DTOs;
using HomeExpenses.Api.Services;
using Microsoft.AspNetCore.Mvc;
namespace HomeExpenses.Api.Controllers;
[ApiController, Route("api/transactions")]
public class TransactionsController(TransactionService service) : ControllerBase
{
    [HttpGet] public async Task<ActionResult> List() => Ok(await service.ListAsync());
    [HttpPost] public async Task<ActionResult> Create(CreateTransactionDto dto) { var result = await service.CreateAsync(dto); return result.Error is null ? CreatedAtAction(nameof(List), result.Data) : BadRequest(new { message = result.Error }); }
}
