using HomeExpenses.Api.DTOs;
using HomeExpenses.Api.Services;
using Microsoft.AspNetCore.Mvc;
namespace HomeExpenses.Api.Controllers;
[ApiController, Route("api/people")]
public class PeopleController(PersonService service) : ControllerBase
{
    [HttpGet] public async Task<ActionResult> List() => Ok(await service.ListAsync());
    [HttpPost] public async Task<ActionResult> Create(CreatePersonDto dto) => CreatedAtAction(nameof(List), await service.CreateAsync(dto));
    [HttpDelete("{id:int}")] public async Task<ActionResult> Delete(int id) => await service.DeleteAsync(id) ? NoContent() : NotFound(new { message = "Person not found." });
}
