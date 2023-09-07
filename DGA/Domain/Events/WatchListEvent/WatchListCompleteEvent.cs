using Domain.Common;
using Domain.Entities;

namespace Domain.Events.WatchListEvent;

public class WatchListCompleteEvent : BaseEvent
{
    public WatchListCompleteEvent(Watchlist movie)
    {
        Watchlist = movie;
    }

    public Watchlist Watchlist { get; }
}