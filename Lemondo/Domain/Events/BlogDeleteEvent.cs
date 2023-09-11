using Domain.Common;
using Domain.Entities;

namespace Domain.Events;

public class BlogDeleteEvent : BaseEvent
{
    public BlogDeleteEvent(Blog blog)
    {
        Blog = blog;
    }
    
    public Blog Blog { get; }
}