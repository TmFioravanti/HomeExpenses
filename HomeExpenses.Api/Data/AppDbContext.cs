using HomeExpenses.Api.Models;
using Microsoft.EntityFrameworkCore;
namespace HomeExpenses.Api.Data;
public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Person> People => Set<Person>();
    public DbSet<Transaction> Transactions => Set<Transaction>();
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Person>().HasMany(p => p.Transactions).WithOne(t => t.Person)
            .HasForeignKey(t => t.PersonId).OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<Transaction>().Property(t => t.Amount).HasPrecision(18, 2);
    }
}
