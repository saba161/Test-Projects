using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Interfaces;

public interface IApplicationDbContext
{
    DbSet<Movie> Movies { get; }
    
    DbSet<Watchlist> Watchlists { get; }
    
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}