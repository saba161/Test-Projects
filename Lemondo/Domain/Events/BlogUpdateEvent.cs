using Domain.Common;
using Domain.Entities;

namespace Domain.Events;

public class BlogUpdateEvent : BaseEvent
{
    public BlogUpdateEvent(Blog blog)
    {
        Blog = blog;
    }

    public Blog Blog { get; }
}