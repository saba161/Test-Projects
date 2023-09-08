using MediatR;

namespace Application.Watchlists.Query.Read;

public class GetWatchListQuery : IRequest<List<GetWatchListQueryResponse>>
{
}