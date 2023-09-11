using Application.Interfaces;
using Domain.Entities;
using Domain.Events;
using FluentValidation;
using MediatR;

namespace Application.Blogs.Commands.Create;

public class CreateBlogCommandHandler : IRequestHandler<CreateBlogCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateBlogCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateBlogCommand request, CancellationToken cancellationToken)
    {
        var validator = new CreateBlogCommandValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
        {
            throw new ValidationException(validationResult.Errors);
        }

        var entity = new Blog
        {
            Title = request.Title,
            Description = request.Description
        };

        entity.AddDomainEvent(new BlogCreateEvent(entity));

        _context.Blogs.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}