using Automarket.Application.Common.Authentications;
using Automarket.Application.Common.Exceptions;
using Automarket.Application.Common.Queries;
using Automarket.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automarket.Application.Authentication.Queries.Login
{
    public class LoginQueryHandler : IQueryHandler<LoginQuery, string>
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

        public async Task<string> Handle(LoginQuery request, CancellationToken cancellationToken)
        {
            var account = await _accountRepository.GetByEmailAsync(request.Email, cancellationToken);
            if (account is null)
            {
                throw new AccountNotFoundException();
            }

            var generatedToken = _jwtTokenGenerator.GenerateToken(account);

            return generatedToken;
        }
    }
}
