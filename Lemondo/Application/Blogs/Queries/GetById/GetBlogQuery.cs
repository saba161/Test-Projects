using MediatR;

namespace Application.Blogs.Queries.GetById;

public class GetBlogQuery : IRequest<GetBlogQueryResponse>
{
    public int Id { get; set; }
}