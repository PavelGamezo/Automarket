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
        Task<Ad> GetAsync(AdId id);
        Task<Ad> AddAsync(Ad ad);
        Task<Ad> UpdateAsync(Ad ad);
        Task<Ad> DeleteAsync(Ad ad);
    }
}
