using HomeExpenses.Api.Data;
using HomeExpenses.Api.DTOs;
using HomeExpenses.Api.Models;
using Microsoft.EntityFrameworkCore;
namespace HomeExpenses.Api.Services;
public class PersonService(AppDbContext db)
{
    public async Task<List<PersonDto>> ListAsync() => await db.People.AsNoTracking().OrderBy(p => p.Name).Select(p => new PersonDto(p.Id, p.Name, p.Age)).ToListAsync();
    public async Task<PersonDto> CreateAsync(CreatePersonDto dto)
    { var person = new Person { Name = dto.Name.Trim(), Age = dto.Age }; db.People.Add(person); await db.SaveChangesAsync(); return new(person.Id, person.Name, person.Age); }
    // Cascade is configured in AppDbContext, so related transactions are removed with the person.
    public async Task<bool> DeleteAsync(int id) { var person = await db.People.FindAsync(id); if (person is null) return false; db.People.Remove(person); await db.SaveChangesAsync(); return true; }
}
