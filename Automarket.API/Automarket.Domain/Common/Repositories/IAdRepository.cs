using Automarket.Domain.AccountAd.Entities;
using Automarket.Domain.AccountAd.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automarket.Domain.Common.Repositories
{
    public interface IAdRepository
    {
        Task<Ad> GetAsync(AdId id, CancellationToken cancellationToken);
        IQueryable<Ad> GetAllAsync(CancellationToken cancellationToken);
        Task AddAsync(Ad ad, CancellationToken cancellationToken);
        Task UpdateAsync(Ad ad, CancellationToken cancellationToken);
        Task DeleteAsync(Ad ad, CancellationToken cancellationToken);
        Task SaveAsync(CancellationToken cancellationToken);
    }
}
