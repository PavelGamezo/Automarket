using Automarket.Shared.Abstractions.ResultObjects;
using MediatR;

namespace Automarket.Application.Ad.Commands.CreateAd
{
    public record class PlaceAccountAdCommand(
        Guid AccountId, 
        string Brand,
        string Model,
        string CarBody, 
        int Year) : IRequest<Result>;
}
