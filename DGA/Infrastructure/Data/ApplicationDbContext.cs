using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Data.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class ApplicationDbContext : DbContext, IApplicationDbContext
{
    public ApplicationDbContext()
    {
    }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new WatchListConfiguration());
        modelBuilder.ApplyConfiguration(new MovieConfiguration());
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer(
                "Server=localhost;Database=Movies;User Id=sa;Password=Password.1;ApplicationIntent=ReadWrite;MultiSubnetFailover=False; TrustServerCertificate=True");
        }
    }

    public DbSet<Movie> Movies { get; set; }
    public DbSet<Watchlist> Watchlists { get; set; }
}