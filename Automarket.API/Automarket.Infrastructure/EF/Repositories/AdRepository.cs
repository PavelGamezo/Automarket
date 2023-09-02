using Automarket.Domain.AccountAd.Entities;
using Automarket.Domain.AccountAd.ValueObjects;
using Automarket.Domain.Common.Repositories;
using Automarket.Infrastructure.EF.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Automarket.Infrastructure.EF.Repositories
{
    public class AdRepository : IAdRepository
    {
        private readonly DbSet<Ad> _ads;
        private readonly ApplicationDbContext _applicationDbContext;

        public AdRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
            _ads = applicationDbContext.Ads;
        }

        public async Task AddAsync(Ad ad, CancellationToken cancellationToken)
        {
            await _ads.AddAsync(ad);
            await SaveAsync(cancellationToken);
        }

        public async Task DeleteAsync(Ad ad, CancellationToken cancellationToken)
        {
            _ads.Remove(ad);
            await SaveAsync(cancellationToken);
        }

        public async Task<Ad> GetAsync(AdId id, CancellationToken cancellationToken)
            => await _ads.SingleOrDefaultAsync(ad => ad.Id == id, cancellationToken);

        public IQueryable<Ad> GetAll(CancellationToken cancellationToken)
            => _ads.AsQueryable();

        public async Task SaveAsync(CancellationToken cancellationToken)
        {
            await _applicationDbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task UpdateAsync(Ad ad, CancellationToken cancellationToken)
        {
            _ads.Update(ad);
            await SaveAsync(cancellationToken);
        }
    }
}
