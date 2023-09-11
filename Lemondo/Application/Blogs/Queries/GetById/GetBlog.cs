using Application.Interfaces;
using AutoMapper;
using MediatR;

namespace Application.Blogs.Queries.GetById;

public class GetBlog : IRequestHandler<GetBlogQuery, GetBlogQueryResponse>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetBlog(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<GetBlogQueryResponse> Handle(GetBlogQuery request, CancellationToken cancellationToken)
    {
        var movie = await _context.Blogs.FindAsync(request.Id);
        var response = _mapper.Map<GetBlogQueryResponse>(movie);

        return response;
    }
}