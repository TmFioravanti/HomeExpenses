using HomeExpenses.Api.Enums;
using System.ComponentModel.DataAnnotations;
namespace HomeExpenses.Api.DTOs;
// Classes are used for request DTOs so ASP.NET Core can apply validation
// attributes consistently when binding JSON requests in controllers.
public class CreatePersonDto
{
    [Required, StringLength(120)] public string Name { get; set; } = string.Empty;
    [Range(0, 150)] public int Age { get; set; }
}
public record PersonDto(int Id, string Name, int Age);
public class CreateTransactionDto
{
    [Required, StringLength(200)] public string Description { get; set; } = string.Empty;
    [Range(0.01, 999999999)] public decimal Amount { get; set; }
    public TransactionType Type { get; set; }
    [Range(1, int.MaxValue)] public int PersonId { get; set; }
}
public record TransactionDto(int Id, string Description, decimal Amount, TransactionType Type, int PersonId, string PersonName, DateTime CreatedAt);
public record PersonSummaryDto(int PersonId, string Name, decimal TotalIncome, decimal TotalExpense, decimal Balance);
public record SummaryDto(IEnumerable<PersonSummaryDto> People, decimal TotalIncome, decimal TotalExpense, decimal TotalBalance);
