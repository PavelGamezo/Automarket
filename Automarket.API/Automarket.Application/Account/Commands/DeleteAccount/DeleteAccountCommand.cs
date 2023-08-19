using Automarket.Application.Common.Commands;
using Automarket.Shared.Abstractions.ResultObjects;

namespace Automarket.Application.Account.Commands.DeleteAccount
{
    public record DeleteAccountCommand(Guid Id) : ICommand<Result>;
}
