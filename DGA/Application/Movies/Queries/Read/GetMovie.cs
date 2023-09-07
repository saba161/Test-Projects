using Application.Interfaces;
using Application.Movies.Queries.GetMovie;
using AutoMapper;
using MediatR;

namespace Application.Movies.Queries.Read;

public class GetMovieQueryHandler : IRequestHandler<GetMovieQuery, GetMovieQueryResponse>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetMovieQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<GetMovieQueryResponse> Handle(GetMovieQuery request, CancellationToken cancellationToken)
    {
        var movie = await _context.Movies.FindAsync(request.Id);
        var response = _mapper.Map<GetMovieQueryResponse>(movie);

        return response;
    }
}