using HomeExpenses.Api.Data;
using HomeExpenses.Api.DTOs;
using HomeExpenses.Api.Enums;
using HomeExpenses.Api.Models;
using Microsoft.EntityFrameworkCore;
namespace HomeExpenses.Api.Services;
public class TransactionService(AppDbContext db)
{
    public async Task<List<TransactionDto>> ListAsync() => await db.Transactions.AsNoTracking().Include(t => t.Person).OrderByDescending(t => t.CreatedAt).Select(t => new TransactionDto(t.Id, t.Description, t.Amount, t.Type, t.PersonId, t.Person!.Name, t.CreatedAt)).ToListAsync();
    public async Task<(TransactionDto? Data, string? Error)> CreateAsync(CreateTransactionDto dto)
    {
        var person = await db.People.FindAsync(dto.PersonId);
        if (person is null) return (null, "The informed person does not exist.");
        // Business rule: minors can register expenses only, never income.
        if (person.Age < 18 && dto.Type == TransactionType.Income) return (null, "Minors can register expenses only.");
        var transaction = new Transaction { Description = dto.Description.Trim(), Amount = dto.Amount, Type = dto.Type, PersonId = person.Id };
        db.Transactions.Add(transaction); await db.SaveChangesAsync();
        return (new(transaction.Id, transaction.Description, transaction.Amount, transaction.Type, person.Id, person.Name, transaction.CreatedAt), null);
    }
}
