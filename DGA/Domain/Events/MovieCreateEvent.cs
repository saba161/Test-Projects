using Domain.Common;
using Domain.Entities;

namespace Domain.Events;

public class MovieCreateEvent : BaseEvent
{
    public MovieCreateEvent(Movie movie)
    {
        Movie = movie;
    }

    public Movie Movie { get; }
}