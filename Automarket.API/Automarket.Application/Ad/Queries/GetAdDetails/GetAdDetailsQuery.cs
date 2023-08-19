using Automarket.Application.Common.Queries;
using Automarket.Application.DTOs;
using Automarket.Shared.Abstractions.ResultObjects;

namespace Automarket.Application.Ad.Queries.GetAds
{
    public record GetAdDetailsQuery(Guid AdId) : IQuery<Result<List<AdDto>>>
    {
    }
}
