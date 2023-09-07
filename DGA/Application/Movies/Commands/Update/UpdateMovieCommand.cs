using MediatR;

namespace Application.Movies.Commands.Update;

public record UpdateMovieCommand : IRequest
{
    public int Id { get; set; }

    public string? Title { get; set; }

    public int? ReleaseYear { get; set; }

    public string? Genre { get; set; }

    public string? Director { get; set; }

    public decimal? Rating { get; set; }

    public string? Description { get; set; }

    public bool? Done { get; set; }
}