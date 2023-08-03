using Automarket.Domain.Entities;
using Automarket.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automarket.Infrastructure.EF.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        public Task AddAsync(Account account, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Account account, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<Account> GetByEmailAsync(string email, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<Account> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task SaveAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Account account, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
