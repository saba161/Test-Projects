using Domain.Common;
using Domain.Entities;

namespace Domain.Events.MovieEvent;

public class MovieCompletedEvent : BaseEvent
{
    public MovieCompletedEvent(Movie movie)
    {
        Movie = movie;
    }

    public Movie Movie { get; }
}