using FluentValidation;
using MovieAPI.Application.DTOs;

namespace MovieAPI.Application.Validators.TagValidators;

public class TagContractValidator : AbstractValidator<TagContract>
{
    public TagContractValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Name cannot be empty.")
            .MinimumLength(1).WithMessage("Name must contain at least one character.");
    }
}
