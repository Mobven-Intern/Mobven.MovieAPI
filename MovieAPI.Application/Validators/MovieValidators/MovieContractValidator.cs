using FluentValidation;
using MovieAPI.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieAPI.Application.Validators.MovieValidators
{
    public class MovieContractValidator : AbstractValidator<MovieContract>
    {
        //Gereksiz?
        public MovieContractValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required.");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Description is required.");
            RuleFor(x => x.ReleaseYear).NotEmpty().GreaterThan(0).WithMessage("Release year must be greater than 0.");
            RuleFor(x => x.ImagePath).NotEmpty().WithMessage("Image path is required.");
            RuleForEach(x => x.GenreList).NotEmpty().WithMessage("Genre list cannot be empty.");
            RuleForEach(x => x.TagList).NotEmpty().WithMessage("Tag list cannot be empty.");
            RuleForEach(x => x.CommentList).NotNull().WithMessage("Comment list cannot be null.");
            RuleFor(x => x.AverageRate).InclusiveBetween(0, 10).WithMessage("Average rate must be between 0 and 10.");
        }
    }
}
