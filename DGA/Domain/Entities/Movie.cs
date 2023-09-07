using Domain.Common;
using Domain.Events;

namespace Domain.Entities;

public class Movie : BaseAuditableEntity
{
    public int Id { get; set; }
    
    public string Name { get; set; }

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