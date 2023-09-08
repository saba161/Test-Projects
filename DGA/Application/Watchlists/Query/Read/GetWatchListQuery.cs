using MediatR;

namespace Application.Watchlists.Query.Read;

public class GetWatchListQuery : IRequest<List<GetWatchListQueryResponse>>
{
    public int UserId { get; set; }
}