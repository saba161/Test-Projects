namespace Domain.Exception.Blog;

public class BlogNotFoundException : DomainException
{
    public BlogNotFoundException(int blogId) : base($"Blog with ID {blogId} not found.")
    {
    }
}