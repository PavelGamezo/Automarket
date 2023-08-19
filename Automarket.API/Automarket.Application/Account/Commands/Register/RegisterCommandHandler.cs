using Automarket.Application.Common.Authentications;
using Automarket.Application.Common.Commands;
using Automarket.Domain.Repositories;
using Automarket.Shared.Abstractions.ResultObjects;

namespace Automarket.Application.Authentication.Commands.Register
{
    public class RegisterCommandHandler : ICommandHandler<RegisterCommand, Result>
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IJwtTokenGenerator _jwtTokenGenerator;

        public RegisterCommandHandler(
            IAccountRepository accountRepository,
            IJwtTokenGenerator jwtTokenGenerator)
        {
            _accountRepository = accountRepository;
            _jwtTokenGenerator = jwtTokenGenerator;
        }

        public async Task<Result> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            var (login, password, fullName, email) = request;
            var id = Guid.NewGuid();

            var validator = new RegisterCommandValidator();
            var validationResult = validator.Validate(request);

            if (!validationResult.IsValid)
            {
                return Result.Fail(new Error(
                    "RegisterCommandHandler.Validation",
                    "Input values is not valid"));
            }

            var accountEntity = new Domain.Account.Entities.Account(id, login, fullName, password, email);
            await _accountRepository.AddAsync(accountEntity, cancellationToken);

            return Result.Success();
        }
    }
}
