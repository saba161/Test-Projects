using Domain.Common;
using Domain.Entities;

namespace Domain.Events.WatchListEvent;

public class WatchListDeleteEvent : BaseEvent
{
    public WatchListDeleteEvent(Watchlist movie)
    {
        Watchlist = movie;
    }

    public Watchlist Watchlist { get; }
}