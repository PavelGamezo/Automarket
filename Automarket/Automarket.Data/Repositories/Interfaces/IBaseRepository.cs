using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automarket.Data.Repositories.Interfaces
{
    public interface IBaseRepository<TEntity> : IDisposable
        where TEntity : class
    {
        IQueryable<TEntity> GetAll();

        Task<TEntity> GetByIdAsync(Guid id);

        Task CreateAsync(TEntity entity);

        void Update(TEntity entity, Guid id);

        Task DeleteAsync(Guid id);

        Task SaveAsync();
    }
}
