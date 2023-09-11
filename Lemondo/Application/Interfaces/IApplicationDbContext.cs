using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Interfaces;

public interface IApplicationDbContext
{
    DbSet<Blog> Blogs { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}