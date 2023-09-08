using FluentValidation;

namespace Application.Movies.Queries.Search;

public class SearchMoviesQueryValidator : AbstractValidator<SearchMoviesQuery>
{
    public SearchMoviesQueryValidator()
    {
        RuleFor(x => x.SearchTerm)
            .NotEmpty()
            .WithMessage("SearchTerm is required.")
            .MaximumLength(255)
            .WithMessage("SearchTerm cannot exceed 255 characters.");
    }
}