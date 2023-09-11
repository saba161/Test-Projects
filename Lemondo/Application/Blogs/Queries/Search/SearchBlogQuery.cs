using System.ComponentModel.DataAnnotations;
using MediatR;

namespace Application.Blogs.Queries.Search;

public class SearchBlogQuery : IRequest<List<SearchBlogQueryResponse>>
{
    public int Page { get; set; } = 1; 
    
    public int PageSize { get; set; } = 10;

    [DataType(DataType.DateTime)]
    [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-ddTHH:mm:ss}")]
    public DateTimeOffset? DateTime { get; set; }
}