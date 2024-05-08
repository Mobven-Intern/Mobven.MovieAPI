using FluentValidation;
using MovieAPI.Application.DTOs;

namespace MovieAPI.Application.Validators.RateValidators;

public class RateContractValidator : AbstractValidator<RateGetContract>
{
    public RateContractValidator()
    {
        RuleFor(x => x.Rating)
            .InclusiveBetween(0, 10).WithMessage("Rating must be between 0 and 10.");

        RuleFor(x => x.MovieName)
            .NotEmpty().WithMessage("Movie name cannot be empty.");

        RuleFor(x => x.Username)
            .NotEmpty().WithMessage("Username cannot be empty.");
    }
}
