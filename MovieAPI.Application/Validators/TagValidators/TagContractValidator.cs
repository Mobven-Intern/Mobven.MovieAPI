using FluentValidation;
using MovieAPI.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieAPI.Application.Validators.TagValidators
{
    public class TagContractValidator : AbstractValidator<TagContract>
    {
        public TagContractValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name cannot be empty.")
                .MinimumLength(1).WithMessage("Name must contain at least one character.");
        }
    }
}
