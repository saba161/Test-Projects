using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext()
    {
    }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            // Configure your database provider here
            optionsBuilder.UseSqlServer("Server=localhost;Database=Movies;User Id=sa;Password=Password.1;ApplicationIntent=ReadWrite;MultiSubnetFailover=False; TrustServerCertificate=True");
        }
    }

    public DbSet<Movie> Movies { get; set; }
}