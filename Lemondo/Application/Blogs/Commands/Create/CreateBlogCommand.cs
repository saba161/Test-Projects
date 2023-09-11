using MediatR;

namespace Application.Blogs.Commands.Create;

public class CreateBlogCommand : IRequest<int>
{
    public string Title { get; set; }

    public string Description { get; set; }
}