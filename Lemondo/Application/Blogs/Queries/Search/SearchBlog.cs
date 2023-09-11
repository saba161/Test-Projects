using Application.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using FluentValidation;
using MediatR;

namespace Application.Blogs.Queries.Search;

public class SearchBlog : IRequestHandler<SearchBlogQuery, List<SearchBlogQueryResponse>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public SearchBlog(IMapper mapper, IApplicationDbContext context)
    {
        _mapper = mapper;
        _context = context;
    }

    public async Task<List<SearchBlogQueryResponse>> Handle(SearchBlogQuery request,
        CancellationToken cancellationToken)
    {
        var validator = new SearchBlogQueryValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
        {
            throw new ValidationException(validationResult.Errors);
        }

        var blogs = _context.Blogs.AsQueryable();

        if (request.DateTime.HasValue)
        {
            blogs = blogs.Where(blog => blog.Created == request.DateTime);
        }

        // Calculate how many items to skip
        var skip = (request.Page - 1) * request.PageSize;

        // Apply pagination using Skip and Take
        var pagedBlogs = blogs
            .Skip(skip)
            .Take(request.PageSize)
            .ProjectTo<SearchBlogQueryResponse>(_mapper.ConfigurationProvider)
            .ToList();

        return pagedBlogs;
    }
}