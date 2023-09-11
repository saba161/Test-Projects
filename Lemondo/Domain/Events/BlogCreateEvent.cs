using Domain.Common;
using Domain.Entities;

namespace Domain.Events;

public class BlogCreateEvent : BaseEvent
{
    public BlogCreateEvent(Blog blog)
    {
        Blog = blog;
    }
    
    public Blog Blog { get; }
}