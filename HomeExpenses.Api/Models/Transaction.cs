using HomeExpenses.Api.Enums;
using System.ComponentModel.DataAnnotations;
namespace HomeExpenses.Api.Models;
public class Transaction
{
    public int Id { get; set; }
    [Required, StringLength(200)] public string Description { get; set; } = string.Empty;
    [Range(0.01, 999999999)] public decimal Amount { get; set; }
    public TransactionType Type { get; set; }
    public int PersonId { get; set; }
    public Person? Person { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}
