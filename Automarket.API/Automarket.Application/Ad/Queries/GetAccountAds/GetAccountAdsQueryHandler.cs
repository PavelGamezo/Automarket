using Automarket.Application.Ad.Queries.GetAdById;
using Automarket.Application.Common.Queries;
using Automarket.Application.DTOs;
using Automarket.Domain.Common.Repositories;
using Automarket.Domain.Repositories;
using Automarket.Shared.Abstractions.ResultObjects;

namespace Automarket.Application.Ad.Queries.GetAd
{
    public class GetAccountAdsQueryHandler : IQueryHandler<GetAccountAdsQuery, Result<List<AdDto>>>
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IAdRepository _adRepository;

        public GetAccountAdsQueryHandler(IAccountRepository accountRepository,IAdRepository adRepository)
        {
            _accountRepository = accountRepository;
            _adRepository = adRepository;
        }

        public async Task<Result<List<AdDto>>> Handle(GetAccountAdsQuery request, CancellationToken cancellationToken)
        {
            var account = await _accountRepository.GetByIdAsync(request.AccountAd, cancellationToken);
            var ads = account.Ads.Select(a => new AdDto(
                a.Id, 
                a.CarBody, 
                a.Brand,
                a.Model,
                a.Year)).ToList();

            if (ads is null)
            {
                return Result.Fail<List<AdDto>>(new Error(
                    "Can't get ads list from account",
                    "GetAccountAdsQueryHandler.Handle"));
            }

            return Result.Success(ads);
        }
    }
}
