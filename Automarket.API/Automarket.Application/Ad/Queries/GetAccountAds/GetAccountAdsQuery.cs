using Automarket.Application.Common.Queries;
using Automarket.Application.DTOs;
using Automarket.Shared.Abstractions.ResultObjects;

namespace Automarket.Application.Ad.Queries.GetAdById
{
    public record class GetAccountAdsQuery(Guid AccountAd) : IQuery<Result<List<AdDto>>>;
}
