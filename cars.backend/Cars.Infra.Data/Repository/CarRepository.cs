using Cars.Domain.Entities;
using Cars.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Cars.Infra.Data.Repository
{
    public class CarRepository : ICarRepository
    {
        private readonly DataContext _context;
        public DbContext Context => _context;

        public CarRepository(DataContext context)
        {
            this._context = context;
        }
        public async Task<List<Car>> List()
        {
            return await _context.Cars.ToListAsync();
        }
        public async Task<Car> Add(Car car)
        {
            await _context.Cars.AddAsync(car);
            await _context.SaveChangesAsync();

            return car;
        }
        public async Task<Car> Get(Guid id)
        {
            return await _context.Cars.FindAsync(id);
        }
        public async Task Delete(Car car)
        {
            _context.Cars.Remove(car);
            await _context.SaveChangesAsync();
        }
        public async Task Update(Car car)
        {
            _context.Cars.Update(car);
            await _context.SaveChangesAsync();
        }
        public void Dispose()
        {
            _context.Dispose();
        }

    }
}
