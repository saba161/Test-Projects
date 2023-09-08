using FluentValidation;

namespace Application.Watchlists.Command.Create;

public class CreateWatchListCommandValidator : AbstractValidator<CreateWatchListCommand>
{
    public CreateWatchListCommandValidator()
    {
        RuleFor(x => x.UserId)
            .NotEmpty()
            .WithMessage("UserId is required.");

        RuleFor(x => x.MovieId)
            .NotEmpty()
            .WithMessage("MovieId is required.");
    }
}