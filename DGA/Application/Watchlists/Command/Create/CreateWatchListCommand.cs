using MediatR;

namespace Application.Watchlists.Command.Create;

public class CreateWatchListCommand : IRequest<int>
{
    public int UserId { get; set; }
    
    public int MovieId { get; set; }
}