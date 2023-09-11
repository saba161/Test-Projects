using MediatR;

namespace Application.Blogs.Commands.Delete;

public record DeleteBlogCommand(int Id) : IRequest;