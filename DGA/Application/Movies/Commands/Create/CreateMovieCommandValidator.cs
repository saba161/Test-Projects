using FluentValidation;

namespace Application.Movies.Commands.Create;

public class CreateMovieCommandValidator : AbstractValidator<CreateMovieCommand>
{
    public CreateMovieCommandValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty()
            .WithMessage("Title is required.")
            .MaximumLength(255)
            .WithMessage("Title cannot exceed 50 characters.");

        RuleFor(x => x.ReleaseYear)
            .InclusiveBetween(1800, DateTime.Now.Year)
            .WithMessage("Invalid release year.");

        RuleFor(x => x.Genre)
            .NotEmpty()
            .WithMessage("Genre is required.")
            .MaximumLength(15)
            .WithMessage("Genre cannot exceed 15 characters.");

        RuleFor(x => x.Director)
            .NotEmpty()
            .WithMessage("Director is required.")
            .MaximumLength(20)
            .WithMessage("Director cannot exceed 20 characters.");

        RuleFor(x => x.Rating)
            .InclusiveBetween(0, 10)
            .WithMessage("Rating must be between 0 and 10.");

        RuleFor(x => x.Description)
            .MaximumLength(1000)
            .WithMessage("Description cannot exceed 1000 characters.");
    }
}