using Automarket.Application.Common.Exceptions;
using Automarket.Domain.AccountAd.Entities;
using Automarket.Domain.Common.Repositories;
using Automarket.Domain.Repositories;
using Automarket.Shared.Abstractions.ResultObjects;
using MediatR;

namespace Automarket.Application.Ad.Commands.CreateAd
{
    public class PlaceAccountAdCommandHandler : IRequestHandler<PlaceAccountAdCommand, Result>
    {
        private readonly IAdRepository _adRepository;
        private readonly IAccountRepository _accountRepository;

        public PlaceAccountAdCommandHandler(IAdRepository adRepository, IAccountRepository accountRepository)
        {
            _adRepository = adRepository;
            _accountRepository = accountRepository;
        }

        public async Task<Result> Handle(PlaceAccountAdCommand request, CancellationToken cancellationToken)
        {
            var (accountId, brand, model, carBody, year) = request;
            var entityId = Guid.NewGuid();

            var validator = new PlaceAccountAdCommandValidator();
            var validationResult = validator.Validate(request);
            if (validationResult.IsValid == false)
            {
                throw new ValidationException(validationResult.Errors);
            }

            var account = await _accountRepository.GetByIdAsync(accountId, cancellationToken);
            if (account is null)
            {
                return Result.Fail(new Error(
                    "PlaceAccountAdCommandHandler.Handle",
                    "Can't find account"));
            }
            var adResult = Domain.AccountAd.Entities.Ad.CreateAd(account ,entityId, brand, model, carBody, year);
            if (adResult.Value is null)
            {
                return Result.Fail(new Error(
                    "PlaceAccountAdCommandHandler.Handle",
                    "Can't create new ad entity"));
            }

            account.PlaceAccountAd(adResult.Value);

            await _adRepository.AddAsync(adResult.Value, cancellationToken);

            return Result.Success();
        }
    }
}
