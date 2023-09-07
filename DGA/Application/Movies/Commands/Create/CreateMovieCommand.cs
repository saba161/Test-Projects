using MediatR;

namespace Application.Movies.Commands.CreateMovie;

public record CreateMovieCommand : IRequest<int>
{
    public string Name { get; set; }

    public string Description { get; set; }
}