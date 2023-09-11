using FluentValidation;

namespace Application.Blogs.Queries.Search;

public class SearchBlogQueryValidator : AbstractValidator<SearchBlogQuery>
{
    public SearchBlogQueryValidator()
    {
    }
}