using Domain.Entities;
using MediatR;

namespace Application.Movies.Queries.GetMovie;

public record GetMovieQuery : IRequest
{
    public int Id { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public List<Watchlist> Watchlists { get; set; }
}