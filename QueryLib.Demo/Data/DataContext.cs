using Microsoft.EntityFrameworkCore;
using QueryLib.Demo.Models;

namespace QueryLib.Demo.Data;

/// <inheritdoc />
public class DataContext(DbContextOptions<DataContext> options) : DbContext(options)
{
    /// <inheritdoc />
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Person>()
            .Property(s => s.Id)
            .IsRequired();
        
        modelBuilder.Entity<Person>()
            .Property(s => s.Name)
            .IsRequired();
        
        modelBuilder.Entity<Vehicle>()
            .Property(s => s.Id)
            .IsRequired();
        
        modelBuilder.Entity<Vehicle>()
            .Property(s => s.Model)
            .IsRequired();
    }
}