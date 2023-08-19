using Automarket.Application.Common.Commands;
using Automarket.Shared.Abstractions.ResultObjects;

namespace Automarket.Application.Authentication.Commands.Register
{
    public record RegisterCommand(string Login, string Password, string FullName, string Email) : ICommand<Result>;
}
