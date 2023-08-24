using FluentValidation;

namespace Automarket.Application.Authentication.Queries.Login
{
    public class LoginQueryValidator : AbstractValidator<LoginQuery>
    {
        public LoginQueryValidator()
        {
            RuleFor(q => q.Login)
                .NotEmpty()
                .WithMessage(q => $"{q.Login} is required")
                .MaximumLength(100).WithMessage("login must not exceed 100 characters.");

            RuleFor(q => q.FullName)
                .NotEmpty().WithMessage(q => $"{q.FullName} is required.")
                .MaximumLength(100).WithMessage("FullName must not exceed 100 characters.");

            RuleFor(q => q.Email)
                .NotEmpty().WithMessage(q => $"{q.Email} is required")
                .EmailAddress().WithMessage("Email is not valid")
                .MaximumLength(200).WithMessage("Email must not exceed 200 characters.");
        }
    }
}
