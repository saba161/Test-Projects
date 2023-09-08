using Domain.Entities;

namespace Application.Watchlists.Query.Read;

public class GetWatchListQueryResponse
{
    public int UserId { get; set; }

    public Movie Movie { get; set; }
    
}