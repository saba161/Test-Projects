using Application.Movies.Commands.Update;
using Application.Movies.Queries.Read;
using Application.Movies.Queries.Search;
using AutoMapper;
using Domain.Entities;

namespace Application.Mapper;

public class MovieProfile : Profile
{
    public MovieProfile()
    {
        CreateMap<UpdateMovieCommand, Movie>();
        CreateMap<Movie, GetMovieQueryResponse>();
        CreateMap<Movie, SearchMoviesQueryResponse>();
    }
}