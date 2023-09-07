using MediatR;

namespace Application.Watchlists.Command.MarkedWatch;

public class MarkedWatchlistCommand : IRequest
{
    public int WatchListId { get; set; }
    public bool Watch { get; set; }
}