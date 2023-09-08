using Application.Interfaces;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Watchlists.Query.Read;

public class GetWatchListQueryHandler : IRequestHandler<GetWatchListQuery, List<GetWatchListQueryResponse>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetWatchListQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<GetWatchListQueryResponse>> Handle(GetWatchListQuery request,
        CancellationToken cancellationToken)
    {
        var watchListe = _context.Watchlists
            .Include(x => x.Movie)
            .Where(x => x.UserID == request.UserId);

        var result = watchListe.Select(x => new GetWatchListQueryResponse
        {
            UserId = x.UserID,
            Movie = x.Movie
        }).ToList();

        return result;
    }
}