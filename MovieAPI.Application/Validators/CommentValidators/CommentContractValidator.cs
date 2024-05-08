using FluentValidation;
using MovieAPI.Application.DTOs;

namespace MovieAPI.Application.Validators.CommentValidators;

public class CommentContractValidator : AbstractValidator<CommentContract>
{
    public CommentContractValidator()
    {
        RuleFor(x => x.Description).NotEmpty().WithMessage("Description is required.");
        RuleFor(x => x.Username).NotEmpty().WithMessage("Username is required.");
        RuleFor(x => x.MovieName).NotEmpty().WithMessage("Movie name is required.");
    }
}
