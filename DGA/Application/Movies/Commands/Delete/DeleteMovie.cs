using Application.Interfaces;
using Domain.Events.MovieEvent;
using MediatR;

namespace Application.Movies.Commands.Delete;

public class DeleteMovieCommandHandler : IRequestHandler<DeleteMovieCommand>
{
    private readonly IApplicationDbContext _context;

    public DeleteMovieCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(DeleteMovieCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Movies
            .FindAsync(request.Id, cancellationToken);

        if (entity == null)
        {
            throw new ArgumentNullException(nameof(entity));
        }

        _context.Movies.Remove(entity);

        entity.RemoveDomainEvent(new MovieDeleteEvent(entity));

        await _context.SaveChangesAsync(cancellationToken);
    }
}