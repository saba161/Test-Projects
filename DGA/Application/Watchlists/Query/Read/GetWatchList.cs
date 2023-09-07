using Application.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Watchlists.Query.Read;

public class GetWatchListQueryHandler : IRequestHandler<GetWatchListQuery, GetWatchListQueryResponse>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetWatchListQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<GetWatchListQueryResponse> Handle(GetWatchListQuery request,
        CancellationToken cancellationToken)
    {
        var watchListe = _context.Watchlists
            .Include(x => x.Movie);

        var response = _mapper.Map<GetWatchListQueryResponse>(watchListe);


        return response;
    }
}