using Automarket.Application.Common.Commands;
using Automarket.Application.Common.Exceptions;
using Automarket.Domain.Common.Repositories;
using Automarket.Domain.Repositories;
using Automarket.Shared.Abstractions.ResultObjects;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automarket.Application.Ad.Commands.DeleteAd
{
    public class RemoveAccountAdCommandHandler : ICommandHandler<RemoveAccountAdCommand, Result>
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IAdRepository _adRepository;

        public RemoveAccountAdCommandHandler(IAccountRepository accountRepository, IAdRepository adRepository)
        {
            _accountRepository = accountRepository;
            _adRepository = adRepository;
        }

        public async Task<Result> Handle(RemoveAccountAdCommand request, CancellationToken cancellationToken)
        {
            var account = await _accountRepository.GetByIdAsync(request.AccountId, cancellationToken);

            var adRemoveResult = account.RemoveAd(request.AdId);
            if (adRemoveResult.IsFailure && adRemoveResult.Value is null)
            {
                return adRemoveResult;
            }

            await _adRepository.AddAsync(adRemoveResult.Value, cancellationToken);

            return Result.Success();
        }
    }
}
