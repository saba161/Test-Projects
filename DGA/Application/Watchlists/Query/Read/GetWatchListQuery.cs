using MediatR;

namespace Application.Watchlists.Query.Read;

public class GetWatchListQuery : IRequest<GetWatchListQueryResponse>
{
    public int ListId { get; init; }
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 10;
}