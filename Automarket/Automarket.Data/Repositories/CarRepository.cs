using Automarket.Data.Repositories.Interfaces;
using Automarket.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automarket.Data.Repositories
{
    public class CarRepository : ICarRepository
    {
        private bool disposed = false;
        private readonly ApplicationDbContext _context;

        public CarRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(Car entity)
        {
            await _context.Cars.AddAsync(entity).AsTask();
        }

        public async Task DeleteAsync(Guid id)
        {
            var car = await GetByIdAsync(id);

            if(car is not null)
            {
                _context.Remove(car);
            }
        }

        public virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public IQueryable<Car> GetAll()
        {
            return _context.Cars.AsQueryable();
        }

        public async Task<Car> GetByIdAsync(Guid id)
        {
            return await _context.Cars.Include(q => q.User).FirstOrDefaultAsync(q => q.CarId == id);
        }

        public Task SaveAsync()
        {
            return _context.SaveChangesAsync();
        }

        public void Update(Car entity, Guid id)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }
    }
}
