using MediatR;

namespace Application.Movies.Commands.Create;

public record CreateMovieCommand : IRequest<int>
{
    public string Name { get; set; }

    public string Description { get; set; }
}