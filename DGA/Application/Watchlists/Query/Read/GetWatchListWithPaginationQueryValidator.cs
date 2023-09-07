using FluentValidation;

namespace Application.Watchlists.Query.Read;

public class GetWatchListWithPaginationQuery : AbstractValidator<GetWatchListQuery>
{
    public GetWatchListWithPaginationQuery()
    {
        RuleFor(x => x.ListId)
            .NotEmpty()
            .WithMessage("ListId is required.");

        RuleFor(x => x.PageNumber)
            .GreaterThanOrEqualTo(1)
            .WithMessage("PageNumber must be greater than or equal to 1.");

        RuleFor(x => x.PageSize)
            .GreaterThanOrEqualTo(1)
            .WithMessage("PageSize must be greater than or equal to 1.");
    }
}