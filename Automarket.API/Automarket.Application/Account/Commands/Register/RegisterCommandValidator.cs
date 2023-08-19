using FluentValidation;

namespace Automarket.Application.Authentication.Commands.Register
{
    public sealed class RegisterCommandValidator : AbstractValidator<RegisterCommand>
    {
        public RegisterCommandValidator()
        {
            RuleFor(command => command.Login)
                .NotEmpty()
                .WithMessage(q => $"{q.Login} is required")
                .MaximumLength(100).WithMessage("login must not exceed 100 characters.");

            RuleFor(command => command.FullName)
                .NotEmpty().WithMessage(command => $"{command.FullName} is required.")
                .MaximumLength(100).WithMessage("FullName must not exceed 100 characters.");

            RuleFor(command => command.Email)
                .NotEmpty().WithMessage(command => $"{command.Email} is required")
                .EmailAddress().WithMessage("Email is not valid")
                .MaximumLength(200).WithMessage("Email must not exceed 200 characters.");

            RuleFor(command=>command.Password)
                .NotEmpty().WithMessage("Password is required")
                .MinimumLength(8).WithMessage("login must not exceed 100 characters.")
                .MaximumLength(100).WithMessage("login must not exceed 100 characters.");
        }
    }
}
