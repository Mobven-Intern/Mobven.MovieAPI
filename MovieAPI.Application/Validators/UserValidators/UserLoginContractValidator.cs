using FluentValidation;
using MovieAPI.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieAPI.Application.Validators.UserValidators
{
    public class UserLoginContractValidator :AbstractValidator<UserLoginContract>
    {
        public UserLoginContractValidator()
        {
            
            RuleFor(x => x.Email).Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Email is Required")
                .When(x=> !string.IsNullOrWhiteSpace(x.Email))
                .NotNull().WithMessage("Email cannot be null")
                .When(x => !string.IsNullOrWhiteSpace(x.Email))
                .EmailAddress().WithMessage("Invalid email")
                .When(x => !string.IsNullOrWhiteSpace(x.Email));
            RuleFor(x => x.Password)
                .Cascade(CascadeMode.Stop) 
                .NotEmpty().WithMessage("Password Required")
                .When(x => !string.IsNullOrWhiteSpace(x.Password)) 
                .NotNull().WithMessage("Password cannot be null")
                .When(x => !string.IsNullOrWhiteSpace(x.Password));


        }
    }
}
