using Automarket.Domain.Account.Entities;
using Automarket.Domain.Repositories;
using Automarket.Infrastructure.EF.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Automarket.Infrastructure.EF.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly DbSet<Account> _accounts;
        private readonly ApplicationDbContext _applicationDbContext;

        public AccountRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
            _accounts = applicationDbContext.Accounts;
        }

        public async Task AddAsync(Account account, CancellationToken cancellationToken)
        {
            await _accounts.AddAsync(account, cancellationToken);
            await SaveAsync(cancellationToken);
        }

        public async Task DeleteAsync(Account account, CancellationToken cancellationToken)
        {
            _accounts.Remove(account);
            await SaveAsync(cancellationToken);
        }

        public async Task<Account> GetByEmailAsync(string email, CancellationToken cancellationToken)
        {
            var account =  await _accounts
                .Include(a=>a.Ads)
                .SingleOrDefaultAsync(
                    account => account.Email == email, 
                    cancellationToken);

            return account;
        }

        public async Task<Account> GetByIdAsync(Guid id, CancellationToken cancellationToken)
            =>  await _accounts.Include(a=>a.Ads).SingleOrDefaultAsync(
                account => account.Id == id, 
                cancellationToken);

        public async Task SaveAsync(CancellationToken cancellationToken)
        {
            await _applicationDbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task UpdateAsync(Account account, CancellationToken cancellationToken)
        {
            _accounts.Update(account);
            await SaveAsync(cancellationToken);
        }
    }
}
