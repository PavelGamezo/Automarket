using Automarket.Application.Common.Commands;
using Automarket.Domain.Repositories;
using Automarket.Shared.Abstractions.ResultObjects;

namespace Automarket.Application.Account.Commands.DeleteAccount
{
    public sealed class DeleteAccountCommandHandler : ICommandHandler<DeleteAccountCommand, Result>
    {
        private readonly IAccountRepository _accountRepository;

        public DeleteAccountCommandHandler(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public async Task<Result> Handle(DeleteAccountCommand request, CancellationToken cancellationToken)
        {
            var entity = await _accountRepository.GetByIdAsync(request.Id, cancellationToken);
            if (entity is null)
            {
                Result.Fail(new Error(
                    "DeleteAccountHandler",
                    "Can't find needed Account entity by ID"));
            }

            await _accountRepository.DeleteAsync(entity, cancellationToken);

            return Result.Success();
        }
    }
}
