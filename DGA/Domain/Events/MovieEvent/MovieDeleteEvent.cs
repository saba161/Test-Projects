using Domain.Common;
using Domain.Entities;

namespace Domain.Events.MovieEvent;

public class MovieDeleteEvent : BaseEvent
{
    public MovieDeleteEvent(Movie movie)
    {
        Movie = movie;
    }

    public Movie Movie { get; }
}