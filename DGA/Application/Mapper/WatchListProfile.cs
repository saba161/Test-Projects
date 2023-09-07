using Application.Movies.Commands.Update;
using Application.Movies.Queries.GetMovie;
using Application.Watchlists.Query.Read;
using AutoMapper;
using Domain.Entities;

namespace Application.Mapper;

public class WatchListProfile : Profile
{
    public WatchListProfile()
    {
        CreateMap<Watchlist, GetWatchListQueryResponse>();
    }
}