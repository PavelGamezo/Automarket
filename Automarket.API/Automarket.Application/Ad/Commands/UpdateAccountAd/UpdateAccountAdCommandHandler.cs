using Automarket.Application.Common.Commands;
using Automarket.Application.Common.Exceptions;
using Automarket.Domain.Common.Repositories;
using Automarket.Domain.Repositories;
using Automarket.Shared.Abstractions.ResultObjects;

namespace Automarket.Application.Ad.Commands.UpdateAd
{
    public class UpdateAccountAdCommandHandler : ICommandHandler<UpdateAccountAdCommand, Result<Guid>>
    {
        private readonly IAdRepository _adRepository;
        private readonly IAccountRepository _accountRepository;

        public UpdateAccountAdCommandHandler(IAdRepository adRepository, IAccountRepository accountRepository)
        {
            _adRepository = adRepository;
            _accountRepository = accountRepository;
        }

        public async Task<Result<Guid>> Handle(UpdateAccountAdCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateAccountAdCommandValidator();
            var validatonResult = validator.Validate(request);

            if (validatonResult.IsValid ==  false)
            {
                throw new ValidationException(validatonResult.Errors);
            }

            var account = await _accountRepository.GetByIdAsync(request.AccountId, cancellationToken);
            if (account is null)
            {
                return Result.Fail<Guid>(new Error(
                    "UpdateAccountAdCommandHandler.Handle",
                    "Can't get account by input id"));
            }

            var adResult = account.GetAdById(request.AdId);

            if (adResult.IsFailure && adResult.Value is null)
            {
                return Result.Fail<Guid>(new Error(
                    "UpdateAccountAdCommandHandler.Handle",
                    "Can't get ad from this account"));
            }

            await _adRepository.UpdateAsync(adResult.Value, cancellationToken);

            return Result.Success(adResult.Value.Id);
        }
    }
}
