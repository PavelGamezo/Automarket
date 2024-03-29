﻿using FluentValidation;

namespace Automarket.Application.Ad.Commands.UpdateAd
{
    public class UpdateAccountAdCommandValidator : AbstractValidator<UpdateAccountAdCommand>
    {
        public UpdateAccountAdCommandValidator()
        {
            RuleFor(c => c.AccountId)
                .NotEmpty().WithMessage("Id must be not empty.");

            RuleFor(c => c.AdId)
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
