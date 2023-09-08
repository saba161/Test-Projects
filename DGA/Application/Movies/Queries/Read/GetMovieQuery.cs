using MediatR;

namespace Application.Movies.Queries.Read;

public class GetMovieQuery : IRequest<GetMovieQueryResponse> 
{
    public int Id { get; set; }
}