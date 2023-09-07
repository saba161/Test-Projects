using Domain.Common;
using Domain.Entities;

namespace Domain.Events.WatchListEvent;

public class WatchListCreateEvent : BaseEvent
{
    public WatchListCreateEvent(Watchlist movie)
    {
        Watchlist = movie;
    }

    public Watchlist Watchlist { get; }
}