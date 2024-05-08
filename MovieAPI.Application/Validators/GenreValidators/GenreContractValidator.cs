using FluentValidation;
using MovieAPI.Application.DTOs;

namespace MovieAPI.Application.Validators.GenreValidators;

public class GenreContractValidator : AbstractValidator<GenreContract>
{
    public GenreContractValidator() 
    {
        RuleFor(x=> x.Name).NotEmpty().WithMessage("Name is required!");
        
    }
}
