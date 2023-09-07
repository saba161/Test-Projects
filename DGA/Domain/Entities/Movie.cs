using Domain.Common;
using Domain.Events;
using Domain.Events.MovieEvent;

namespace Domain.Entities;

public class Movie : BaseAuditableEntity
{
    public int Id { get; set; }

    public string Title { get; set; }

    public int ReleaseYear { get; set; }

    public string Genre { get; set; }

    public string Director { get; set; }

    public decimal Rating { get; set; }
    
    public string Description { get; set; }

    private bool _done;

    public bool Done
    {
        get => _done;
        set
        {
            if (value && !_done)
            {
                AddDomainEvent(new MovieCompletedEvent(this));
            }

            _done = value;
        }
    }
}