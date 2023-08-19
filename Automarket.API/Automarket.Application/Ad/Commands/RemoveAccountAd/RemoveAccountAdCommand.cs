using Automarket.Application.Common.Commands;
using Automarket.Shared.Abstractions.ResultObjects;

namespace Automarket.Application.Ad.Commands.DeleteAd
{
    public record class RemoveAccountAdCommand(Guid AccountId, Guid AdId) : ICommand<Result>;
}
