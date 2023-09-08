using Application.Interfaces;
using Domain.Entities;
using Domain.Events.WatchListEvent;
using FluentValidation;
using MediatR;

namespace Application.Watchlists.Command.Create;

public class CreateWatchListCommandHandler : IRequestHandler<CreateWatchListCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateWatchListCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateWatchListCommand request, CancellationToken cancellationToken)
    {
        var validator = new CreateWatchListCommandValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
        {
            throw new ValidationException(validationResult.Errors);
        }

        var entity = new Watchlist()
        {
            UserID = request.UserId,
            MovieID = request.MovieId,
            Watch = false
        };

        entity.AddDomainEvent(new WatchListCreateEvent(entity));

        _context.Watchlists.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}