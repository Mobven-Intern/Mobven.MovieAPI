﻿using FluentValidation;
using MovieAPI.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieAPI.Application.Validators.UserValidators
{
    public class UserRegisterContractValidator : AbstractValidator<UserRegisterContract>
    {
        public UserRegisterContractValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty().WithMessage("First name is required.");
            RuleFor(x => x.LastName).NotEmpty().WithMessage("Last name is required.");
            RuleFor(x => x.Email).NotEmpty().EmailAddress().WithMessage("Invalid email address.");
            RuleFor(x => x.Username).NotEmpty().MinimumLength(5).WithMessage("Username must be at least 5 characters.");
            RuleFor(x => x.Password).NotEmpty().MinimumLength(8).WithMessage("Password must be at least 8 characters.");
            RuleFor(x => x.PasswordConfirm).Equal(x => x.Password).WithMessage("Passwords do not match.");
            RuleFor(x => x.BirthDate).NotEmpty().Must(BeAValidDate).WithMessage("Invalid birth date.");
        }
        private bool BeAValidDate(string date)
        {
            return DateTime.TryParse(date, out _);
        }
    }
}
