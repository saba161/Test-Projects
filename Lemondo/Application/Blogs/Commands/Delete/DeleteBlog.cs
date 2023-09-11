using Application.Interfaces;
using Domain.Events;
using MediatR;

namespace Application.Blogs.Commands.Delete;

public class DeleteBlog : IRequestHandler<DeleteBlogCommand>
{
    private readonly IApplicationDbContext _context;

    public DeleteBlog(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(DeleteBlogCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Blogs
            .FindAsync(request.Id, cancellationToken);

        if (entity == null)
        {
            throw new ArgumentNullException(nameof(entity));
        }

        _context.Blogs.Remove(entity);

        entity.RemoveDomainEvent(new BlogDeleteEvent(entity));

        await _context.SaveChangesAsync(cancellationToken);
    }
}