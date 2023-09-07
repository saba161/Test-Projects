using Application.Interfaces;
using Domain.Events.WatchListEvent;
using MediatR;

namespace Application.Watchlists.Command.Delete;

public class DeleteWatchListCommandHandler : IRequestHandler<DeleteWatchListCommand>
{
    private readonly IApplicationDbContext _context;

    public DeleteWatchListCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(DeleteWatchListCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Watchlists
            .FindAsync(request.Id, cancellationToken);

        if (entity == null)
        {
            throw new ArgumentNullException(nameof(entity));
        }

        _context.Watchlists.Remove(entity);

        entity.RemoveDomainEvent(new WatchListDeleteEvent(entity));

        await _context.SaveChangesAsync(cancellationToken);    
    }
}