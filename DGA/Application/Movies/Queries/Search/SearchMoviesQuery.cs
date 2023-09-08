using MediatR;

namespace Application.Movies.Queries.Search;

public class SearchMoviesQuery : IRequest<List<SearchMoviesQueryResponse>>
{
    public string SearchTerm { get; set; }
}