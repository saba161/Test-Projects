using MediatR;

namespace Application.Movies.Commands.UpdateMovie;

public record UpdateMovieCommand : IRequest
{
    public int Id { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public bool Done { get; set; }
}