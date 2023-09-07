using Application.Interfaces;
using AutoMapper;
using MediatR;

namespace Application.Movies.Commands.Update;

public class UpdateMovieCommandHandler : IRequestHandler<UpdateMovieCommand>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public UpdateMovieCommandHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task Handle(UpdateMovieCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Movies
            .FindAsync(new object[] { request.Id }, cancellationToken);

        _mapper.Map(request, entity);
        entity.LastModified = DateTimeOffset.Now;
        _context.Movies.Update(entity);

        await _context.SaveChangesAsync(cancellationToken);
    }
}