using Application.Interfaces;
using MediatR;

namespace Application.Movies.Commands.Update;

public class UpdateMovieCommandHandler : IRequestHandler<UpdateMovieCommand>
{
    private readonly IApplicationDbContext _context;

    public UpdateMovieCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(UpdateMovieCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Movies
            .FindAsync(new object[] { request.Id }, cancellationToken);

        entity.Name = request.Name;
        entity.Description = request.Description;
        entity.Done = request.Done;

        await _context.SaveChangesAsync(cancellationToken);
    }
}