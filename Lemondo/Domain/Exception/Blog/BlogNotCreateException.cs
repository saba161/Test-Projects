namespace Domain.Exception.Blog;

public class BlogNotCreateException : DomainException
{
    public BlogNotCreateException(string message) : base(message)
    {
    }
}