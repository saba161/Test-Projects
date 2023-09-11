using Application.Interfaces;
using AutoMapper;
using Domain.Events;
using FluentValidation;
using MediatR;

namespace Application.Blogs.Commands.Update;

public class UpdateBlog : IRequestHandler<UpdateBlogCommand>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public UpdateBlog(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task Handle(UpdateBlogCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Blogs
            .FindAsync(request.Id, cancellationToken);

        var validator = new UpdateBlogCommandValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
        {
            throw new ValidationException(validationResult.Errors);
        }

        _mapper.Map(request, entity);
        entity.LastModified = DateTimeOffset.Now;

        entity.RemoveDomainEvent(new BlogUpdateEvent(entity));


        _context.Blogs.Update(entity);

        await _context.SaveChangesAsync(cancellationToken);
    }
}