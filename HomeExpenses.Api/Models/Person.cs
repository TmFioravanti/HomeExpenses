using System.ComponentModel.DataAnnotations;
namespace HomeExpenses.Api.Models;
public class Person
{
    public int Id { get; set; }
    [Required, StringLength(120)] public string Name { get; set; } = string.Empty;
    [Range(0, 150)] public int Age { get; set; }
    public ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
}
