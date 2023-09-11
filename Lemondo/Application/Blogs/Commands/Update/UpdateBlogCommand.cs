using MediatR;

namespace Application.Blogs.Commands.Update;

public class UpdateBlogCommand : IRequest
{
    public int Id { get; set; }
    public string Title { get; set; }

    public string Description { get; set; }
}