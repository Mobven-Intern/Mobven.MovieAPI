using FluentValidation;
using MovieAPI.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieAPI.Application.Validators.MovieValidators
{
    public class MovieUpdateContractValidator : AbstractValidator<MovieUpdateContract>
    {
        public MovieUpdateContractValidator()
        {
            RuleFor(x => x.Id).NotEmpty().GreaterThan(0).WithMessage("Id must be greater than 0.");

            RuleFor(x => x.Name).Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Name is Required")
                .When(x => !string.IsNullOrWhiteSpace(x.Name))
                .NotNull().WithMessage("Name cannot be null")
                .When(x => !string.IsNullOrWhiteSpace(x.Name));

            RuleFor(x => x.Description).Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Description is Required")
                .When(x => !string.IsNullOrWhiteSpace(x.Description))
                .NotNull().WithMessage("Description cannot be null")
                .When(x => !string.IsNullOrWhiteSpace(x.Description));

            RuleFor(x => x.ReleaseYear).NotEmpty().GreaterThan(0).WithMessage("Release year must be greater than 0.");

            RuleFor(x => x.ImagePath).Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("ImagePath is Required")
                .When(x => !string.IsNullOrWhiteSpace(x.ImagePath))
                .NotNull().WithMessage("ImagePath cannot be null")
                .When(x => !string.IsNullOrWhiteSpace(x.ImagePath));

            
            RuleForEach(x => x.GenreList)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotNull().WithMessage("GenreList cannot be null")
                .NotEmpty().WithMessage("GenreList is Required");

            RuleForEach(x => x.TagList)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotNull().WithMessage("GenreList cannot be null")
                .NotEmpty().WithMessage("GenreList is Required");
        }
    }
}
