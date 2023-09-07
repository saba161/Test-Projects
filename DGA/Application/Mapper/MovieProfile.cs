using Application.Movies.Commands.Update;
using Application.Movies.Queries.GetMovie;
using AutoMapper;
using Domain.Entities;

namespace Application.Mapper;

public class MovieProfile : Profile
{
    public MovieProfile()
    {
        CreateMap<UpdateMovieCommand, Movie>();
        CreateMap<Movie, GetMovieQueryResponse>();
    }
}