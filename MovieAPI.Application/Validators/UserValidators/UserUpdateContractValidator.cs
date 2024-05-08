using FluentValidation;
using MovieAPI.Application.DTOs;

namespace MovieAPI.Application.Validators.UserValidators;

public class UserUpdateContractValidator : AbstractValidator<UserUpdateContract>
{
    
    public UserUpdateContractValidator()
    {
        RuleFor(x => x.FirstName).NotEmpty().WithMessage("First name is required.");
        RuleFor(x => x.LastName).NotEmpty().WithMessage("Last name is required.");
        RuleFor(x => x.Username).NotEmpty().MinimumLength(5).WithMessage("Username must be at least 5 characters.");
        RuleFor(x => x.Email).NotEmpty().EmailAddress().WithMessage("Invalid email address.");
        RuleFor(x => x.Password).NotEmpty().When(x => !string.IsNullOrEmpty(x.PasswordConfirm)).WithMessage("Password is required.");
        RuleFor(x => x.PasswordConfirm).Equal(x => x.Password).When(x => !string.IsNullOrEmpty(x.Password)).WithMessage("Passwords do not match.");
        RuleFor(x => x.BirthDate).NotEmpty().Must(BeAValidDate).WithMessage("Invalid birth date.");
    }

    private bool BeAValidDate(string date)
    {
        return DateTime.TryParse(date, out _);
    }
}
