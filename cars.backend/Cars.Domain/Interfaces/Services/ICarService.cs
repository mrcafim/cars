using Cars.Domain.Entities;
using Cars.Domain.Models;

namespace Cars.Domain.Interfaces.Services
{
    public interface ICarService
    {
        Task<List<Car>> List();
        Task<Car> Create(CarModel car);
        Task<Car> Get(Guid id);
        Task<bool> Delete(Guid id);
        Task<bool> Update(Guid id, CarModel carModel);
    }
}
