using HomeExpenses.Api.Data;
using HomeExpenses.Api.DTOs;
using HomeExpenses.Api.Enums;
using Microsoft.EntityFrameworkCore;
namespace HomeExpenses.Api.Services;
public class SummaryService(AppDbContext db)
{
    public async Task<SummaryDto> GetAsync()
    {
        var people = await db.People.AsNoTracking().Include(p => p.Transactions).OrderBy(p => p.Name).ToListAsync();
        var rows = people.Select(p => { var income = p.Transactions.Where(t => t.Type == TransactionType.Income).Sum(t => t.Amount); var expense = p.Transactions.Where(t => t.Type == TransactionType.Expense).Sum(t => t.Amount); return new PersonSummaryDto(p.Id, p.Name, income, expense, income - expense); }).ToList();
        return new(rows, rows.Sum(r => r.TotalIncome), rows.Sum(r => r.TotalExpense), rows.Sum(r => r.Balance));
    }
}
