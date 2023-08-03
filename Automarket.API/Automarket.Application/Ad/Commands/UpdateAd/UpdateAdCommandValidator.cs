using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automarket.Application.Ad.Commands.UpdateAd
{
    public class UpdateAdCommandValidator : AbstractValidator<UpdateAdCommand>
    {
        public UpdateAdCommandValidator()
        {
            RuleFor(c => c.Id)
                .NotEmpty().WithMessage("Id must be not empty.");
            
            RuleFor(c => c.CarBody)
                .NotEmpty()
                .WithMessage(c => $"{c.CarBody} is required")
                .MaximumLength(100);

            RuleFor(c => c.Brand)
                .NotEmpty().WithMessage(c => $"{c.Brand} is required.")
                .MaximumLength(100).WithMessage("Brand must not exceed 100 characters.");

            RuleFor(c => c.Model)
                .NotEmpty().WithMessage(c => $"{c.Model} is required")
                .MaximumLength(100).WithMessage("Brand must not exceed 200 characters.");

            RuleFor(c => c.Year)
                .NotNull().WithMessage(c => $"{c.Year} is required")
                .GreaterThan(1910).WithMessage("Year must be greater than 1910.")
                .LessThanOrEqualTo(DateTime.Now.Year).WithMessage($"Year must be less than or equal to {DateTime.Now.Year}");
        }
    }
}
