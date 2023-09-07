using MediatR;

namespace Application.Watchlists.Command.Delete;

public record DeleteWatchListCommand(int Id) : IRequest;