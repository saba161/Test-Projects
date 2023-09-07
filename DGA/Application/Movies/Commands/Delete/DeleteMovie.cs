using Application.Interfaces;
using Domain.Events;
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
            .FindAsync(new object[] { request.Id }, cancellationToken);
        
        _context.Movies.Remove(entity);

        entity.AddDomainEvent(new MovieDeleteEvent(entity));

        await _context.SaveChangesAsync(cancellationToken);
    }
}