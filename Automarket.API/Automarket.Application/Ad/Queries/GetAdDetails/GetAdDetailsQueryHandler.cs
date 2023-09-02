using Automarket.Application.Common.Queries;
using Automarket.Application.DTOs;
using Automarket.Domain.Common.Repositories;
using Automarket.Shared.Abstractions.ResultObjects;

namespace Automarket.Application.Ad.Queries.GetAds
{
    internal sealed class GetAdDetailsQueryHandler : IQueryHandler<GetAdDetailsQuery, Result<List<AdDto>>>
    {
        private readonly IAdRepository _adRepository;

        public GetAdDetailsQueryHandler(IAdRepository adRepository)
        {
            _adRepository = adRepository;
        }

        public async Task<Result<List<AdDto>>> Handle(GetAdDetailsQuery request, CancellationToken cancellationToken)
        {
            var ads = _adRepository.GetAll(cancellationToken);

            if (ads is null)
            {
                return Result.Fail<List<AdDto>>(new Error(
                    "Ad.Queries.GetAdsQueryHandler",
                    "Can't get AdDto objects"));
            }

            var resultAds = ads
                .Select(a => new AdDto(
                    a.Id, 
                    a.CarBody, 
                    a.Brand, 
                    a.Model, 
                    a.Year))
                .ToList();

            return Result.Success<List<AdDto>>(resultAds);
        }
    }
}
