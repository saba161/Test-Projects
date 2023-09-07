using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Interfaces;

public interface IApplicationDbContext
{
    DbSet<Movie> Movies { get; }
    
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}