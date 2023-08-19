using Automarket.Domain.Account.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automarket.Domain.Repositories
{
    public interface IAccountRepository
    {
        Task<Account.Entities.Account> GetByIdAsync(Guid id, CancellationToken cancellationToken);
        Task<Account.Entities.Account> GetByEmailAsync(string email, CancellationToken cancellationToken);
        Task AddAsync(Account.Entities.Account account, CancellationToken cancellationToken);
        Task UpdateAsync(Account.Entities.Account account, CancellationToken cancellationToken);
        Task DeleteAsync(Account.Entities.Account account, CancellationToken cancellationToken);
        Task SaveAsync(CancellationToken cancellationToken);
    }
}
