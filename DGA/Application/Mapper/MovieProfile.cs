using Application.Movies.Commands.Update;
using AutoMapper;
using Domain.Entities;

namespace Application.Mapper;

public class MovieProfile : Profile
{
    public MovieProfile()
    {
        CreateMap<UpdateMovieCommand, Movie>();
    }
}