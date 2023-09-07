using Application.Interfaces;
using MediatR;

namespace Application.Watchlists.Command.MarkedWatch;

public class MarkedWatchlistCommandHandler : IRequestHandler<MarkedWatchlistCommand>
{
    private readonly IApplicationDbContext _context;

    public MarkedWatchlistCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(MarkedWatchlistCommand request, CancellationToken cancellationToken)
    {
        var movieFromWatchList = await _context.Watchlists
            .FindAsync(request.WatchListId);

        movieFromWatchList.Watch = request.Watch;

        _context.Watchlists.Update(movieFromWatchList);
        await _context.SaveChangesAsync(cancellationToken);
    }
}