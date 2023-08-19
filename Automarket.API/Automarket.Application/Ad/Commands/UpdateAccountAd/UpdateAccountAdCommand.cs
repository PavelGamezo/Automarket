using Automarket.Application.Common.Commands;
using Automarket.Shared.Abstractions.ResultObjects;

namespace Automarket.Application.Ad.Commands.UpdateAd
{
    public record class UpdateAccountAdCommand(
        Guid AccountId, 
        Guid AdId, 
        string Brand,
        string Model, 
        string CarBody, 
        int Year) : ICommand<Result<Guid>>;
}
