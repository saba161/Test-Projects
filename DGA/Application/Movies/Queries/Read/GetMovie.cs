using Application.Interfaces;
using MediatR;

namespace Application.Movies.Queries.GetMovie;

public class GetMovieQueryHandler : IRequestHandler<GetMovieQuery>
{
    private readonly IApplicationDbContext _context;

    public GetMovieQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(GetMovieQuery request, CancellationToken cancellationToken)
    {
        
    }
}