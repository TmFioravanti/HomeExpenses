using HomeExpenses.Api.Enums;
using System.ComponentModel.DataAnnotations;
namespace HomeExpenses.Api.DTOs;
public record CreatePersonDto([property: Required, StringLength(120)] string Name, [property: Range(0, 150)] int Age);
public record PersonDto(int Id, string Name, int Age);
public record CreateTransactionDto([property: Required, StringLength(200)] string Description, [property: Range(0.01, 999999999)] decimal Amount, TransactionType Type, [property: Range(1, int.MaxValue)] int PersonId);
public record TransactionDto(int Id, string Description, decimal Amount, TransactionType Type, int PersonId, string PersonName, DateTime CreatedAt);
public record PersonSummaryDto(int PersonId, string Name, decimal TotalIncome, decimal TotalExpense, decimal Balance);
public record SummaryDto(IEnumerable<PersonSummaryDto> People, decimal TotalIncome, decimal TotalExpense, decimal TotalBalance);
