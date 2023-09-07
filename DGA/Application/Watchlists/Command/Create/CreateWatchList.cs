using Application.Interfaces;
using Domain.Entities;
using Domain.Events.WatchListEvent;
using MediatR;

namespace Application.Watchlists.Command.Create;

public class CreateWatchListCommandHandler : IRequestHandler<CreateWatchListCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateWatchListCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateWatchListCommand request, CancellationToken cancellationToken)
    {
        var entity = new Watchlist()
        {
            UserID = request.UserId,
            MovieID = request.MovieId
        };

        entity.AddDomainEvent(new WatchListCreateEvent(entity));

        _context.Watchlists.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}