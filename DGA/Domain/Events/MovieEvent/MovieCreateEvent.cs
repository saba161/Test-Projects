using Domain.Common;
using Domain.Entities;

namespace Domain.Events.MovieEvent;

public class MovieCreateEvent : BaseEvent
{
    public MovieCreateEvent(Movie movie)
    {
        Movie = movie;
    }

    public Movie Movie { get; }
}