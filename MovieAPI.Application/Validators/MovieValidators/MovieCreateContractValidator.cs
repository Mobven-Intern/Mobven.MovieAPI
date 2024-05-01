﻿using FluentValidation;
using MovieAPI.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieAPI.Application.Validators.MovieValidators
{
    public class MovieCreateContractValidator :AbstractValidator<MovieCreateContract>
    {
        public MovieCreateContractValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required.");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Description is required.");
            RuleFor(x => x.ReleaseYear).NotEmpty().GreaterThan(0).WithMessage("Release year must be greater than 0.");
            RuleFor(x => x.ImagePath).NotEmpty().WithMessage("Image path is required.");
            RuleForEach(x => x.GenreList).NotEmpty().WithMessage("Genre list cannot be empty.");
            RuleForEach(x => x.TagList).NotEmpty().WithMessage("Tag list cannot be empty.");
        }
    }
}
