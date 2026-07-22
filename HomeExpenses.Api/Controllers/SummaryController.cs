using HomeExpenses.Api.Services;
using Microsoft.AspNetCore.Mvc;
namespace HomeExpenses.Api.Controllers;
[ApiController, Route("api/summary")]
public class SummaryController(SummaryService service) : ControllerBase { [HttpGet] public async Task<ActionResult> Get() => Ok(await service.GetAsync()); }
