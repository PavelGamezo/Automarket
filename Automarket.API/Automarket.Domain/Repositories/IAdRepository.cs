using Automarket.Domain.Entities;
using Automarket.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automarket.Domain.Repositories
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
