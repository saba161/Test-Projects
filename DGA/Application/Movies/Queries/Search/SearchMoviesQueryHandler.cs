using Application.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;

namespace Application.Movies.Queries.Search;

public class SearchMoviesQueryHandler : IRequestHandler<SearchMoviesQuery, List<SearchMoviesQueryResponse>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public SearchMoviesQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<SearchMoviesQueryResponse>> Handle(SearchMoviesQuery request,
        CancellationToken cancellationToken)
    {
        var movies = _context.Movies
            .Where(movie => movie.Title.Contains(request.SearchTerm))
            .ProjectTo<SearchMoviesQueryResponse>(_mapper.ConfigurationProvider)
            .ToList();

        return movies;
    }
}