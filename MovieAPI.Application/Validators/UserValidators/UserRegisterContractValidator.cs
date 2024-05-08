using FluentValidation;
using MovieAPI.Application.DTOs;

namespace MovieAPI.Application.Validators.UserValidators;

public class UserRegisterContractValidator : AbstractValidator<UserRegisterContract>
{
    public UserRegisterContractValidator()
    {
        RuleFor(x => x.FirstName).Cascade(CascadeMode.Stop)
            .NotEmpty().WithMessage("FirstName is Required")
            .When(x => !string.IsNullOrWhiteSpace(x.FirstName))
            .NotNull().WithMessage("FirstName cannot be null")
            .When(x => !string.IsNullOrWhiteSpace(x.FirstName));

        RuleFor(x => x.LastName).Cascade(CascadeMode.Stop)
            .NotEmpty().WithMessage("LastName is Required")
            .When(x => !string.IsNullOrWhiteSpace(x.LastName))
            .NotNull().WithMessage("LastName cannot be null")
            .When(x => !string.IsNullOrWhiteSpace(x.LastName));

        RuleFor(x => x.Email).Cascade(CascadeMode.Stop)
            .NotEmpty().WithMessage("Email is Required")
            .When(x => !string.IsNullOrWhiteSpace(x.Email))
            .NotNull().WithMessage("Email cannot be null")
            .When(x => !string.IsNullOrWhiteSpace(x.Email))
            .EmailAddress().WithMessage("Invalid email")
            .When(x => !string.IsNullOrWhiteSpace(x.Email));

        RuleFor(x => x.Username).Cascade(CascadeMode.Stop)
            .NotEmpty().WithMessage("Username is Required")
            .When(x => !string.IsNullOrWhiteSpace(x.Username))
            .NotNull().WithMessage("Username cannot be null")
            .When(x => !string.IsNullOrWhiteSpace(x.Username));

        RuleFor(x => x.Password).Cascade(CascadeMode.Stop)
            .NotEmpty().WithMessage("Password is Required")
            .When(x => !string.IsNullOrWhiteSpace(x.Password))
            .NotNull().WithMessage("Password cannot be null")
            .When(x => !string.IsNullOrWhiteSpace(x.Password))
            .MinimumLength(8).WithMessage("You must enter at least 8 characters")
            .When(x => !string.IsNullOrWhiteSpace(x.Password))
            .Matches(@"^(?=.*[A-Z])(?=.*\d).+$").WithMessage("Password must contain at least one uppercase letter and one digit")
            .When(x => !string.IsNullOrWhiteSpace(x.Password));

        RuleFor(x => x.PasswordConfirm).Cascade(CascadeMode.StopOnFirstFailure)
            .Equal(x => x.Password).WithMessage("Passwords do not match.");

        RuleFor(x => x.BirthDate).Cascade(CascadeMode.StopOnFirstFailure)
            .NotEmpty().Must(BeAValidDate).WithMessage("Invalid birth date.");
    }
    private bool BeAValidDate(string date)
    {
        return DateTime.TryParse(date, out _);
    }
}
