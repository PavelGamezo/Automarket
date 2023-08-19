using Automarket.Application.Common.Authentications;
using Automarket.Application.Common.Queries;
using Automarket.Domain.Repositories;
using Automarket.Shared.Abstractions.ResultObjects;

namespace Automarket.Application.Authentication.Queries.Login
{
    public class LoginQueryHandler : IQueryHandler<LoginQuery, Result<string>>
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IJwtTokenGenerator _jwtTokenGenerator;

        public LoginQueryHandler(
            IAccountRepository accountRepository, 
            IJwtTokenGenerator jwtTokenGenerator)
        {
            _accountRepository = accountRepository;
            _jwtTokenGenerator = jwtTokenGenerator;
        }

        public async Task<Result<string>> Handle(LoginQuery request, CancellationToken cancellationToken)
        {
            var validator = new LoginQueryValidator();
            var validatorResult = validator.Validate(request);

            if (validatorResult.IsValid == false)
            {
                return Result.Fail<string>(new Error(
                    "LoginQueryValidator.",
                    "Validation of login request is not correct"));
            }

            var account = await _accountRepository.GetByEmailAsync(request.Email, cancellationToken);
            if (account is null)
            {
                return Result.Fail<string>(new Error(
                    "LoginQueryValidator.",
                    "Can't get account by input email"));
            }

            var generatedToken = _jwtTokenGenerator.GenerateToken(account);

            return Result.Success<string>(generatedToken);
        }
    }
}
