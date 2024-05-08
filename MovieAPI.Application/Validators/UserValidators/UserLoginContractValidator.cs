using FluentValidation;
using MovieAPI.Application.DTOs;

namespace MovieAPI.Application.Validators.UserValidators;

public class UserLoginContractValidator :AbstractValidator<UserLoginContract>
{
    public UserLoginContractValidator()
    {
        RuleFor(x => x.Email).Cascade(CascadeMode.Stop)
            .NotNull().WithMessage("Email cannot be null")
            .NotEmpty().WithMessage("Email is Required")
            .EmailAddress().WithMessage("Invalid email");
        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("Password Required")
            .NotNull().WithMessage("Password cannot be null");
    }
}
