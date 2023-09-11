using Application.Blogs.Commands.Update;
using Application.Blogs.Queries.GetById;
using Application.Blogs.Queries.Search;
using AutoMapper;
using Domain.Entities;

namespace Application.Mapper;

public class BlogProfile : Profile
{
    public BlogProfile()
    {
        CreateMap<UpdateBlogCommand, Blog>();
        CreateMap<Blog, GetBlogQueryResponse>();
        CreateMap<Blog, SearchBlogQueryResponse>();

    }
}