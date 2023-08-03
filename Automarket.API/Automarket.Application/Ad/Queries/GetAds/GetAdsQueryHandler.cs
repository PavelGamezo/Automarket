using Automarket.Application.Common.Queries;
using Automarket.Application.DTOs;
using Automarket.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automarket.Application.Ad.Queries.GetAds
{
    internal sealed class GetAdsQueryHandler : IQueryHandler<GetAdsQuery, List<AdDto>>
    {
        private readonly IAdRepository _adRepository;

        public GetAdsQueryHandler(IAdRepository adRepository)
        {
            _adRepository = adRepository;
        }

        public async Task<List<AdDto>> Handle(GetAdsQuery request, CancellationToken cancellationToken)
        {
            var ads = _adRepository.GetAllAsync(cancellationToken);

            var resultAds = new List<AdDto>();

            foreach (var ad in ads)
            {
                resultAds.Add(new AdDto(ad.Id, ad.CarBody, ad.Brand, ad.Model, ad.Year));
            }

            return resultAds;
        }
    }
}
