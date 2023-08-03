using Automarket.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automarket.Domain.Repositories
{
    public interface IAccountRepository
    {
        Task<Account> GetByIdAsync(Guid id, CancellationToken cancellationToken);
        Task<Account> GetByEmailAsync(string email, CancellationToken cancellationToken);
        Task AddAsync(Account account, CancellationToken cancellationToken);
        Task UpdateAsync(Account account, CancellationToken cancellationToken);
        Task DeleteAsync(Account account, CancellationToken cancellationToken);
        Task SaveAsync(CancellationToken cancellationToken);
    }
}
