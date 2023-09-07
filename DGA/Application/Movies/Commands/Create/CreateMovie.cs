using Application.Interfaces;
using Domain.Entities;
using Domain.Events;
using MediatR;

namespace Application.Movies.Commands.Create;

public class CreateMovieCommandHandler : IRequestHandler<CreateMovieCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateMovieCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateMovieCommand request, CancellationToken cancellationToken)
    {
        var entity = new Movie
        {
            Title = request.Title,
            ReleaseYear = request.ReleaseYear,
            Genre = request.Genre,
            Director = request.Director,
            Rating = request.Rating,
            Description = request.Description,
            Done = false
        };

        entity.AddDomainEvent(new MovieCreateEvent(entity));

        _context.Movies.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}