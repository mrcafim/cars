using Cars.Domain.Entities;
using Cars.Domain.Interfaces.Repositories;
using Cars.Domain.Interfaces.Services;
using Cars.Domain.Models;

namespace Cars.Service
{
    public class CarService : ICarService
    {
        private readonly ICarRepository _repository;

        public CarService(ICarRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Car>> List()
        {
            return await _repository.List();
        }

        public async Task<Car> Create(CarModel carModel)
        {
            if (carModel.Plate.Length > 6) return null;

            var car = new Car
            {
                Make = carModel.Make,
                Model = carModel.Model,
                Color = carModel.Color,
                Plate = carModel.Plate,
                MakeDate = carModel.Date,
            };

            await _repository.Add(car);

            return car;
        }

        public async Task<Car> Get(Guid id)
        {
            return await _repository.Get(id);
        }

        public async Task<bool> Update(Guid id, CarModel carModel)
        {
            if (carModel.Plate.Length > 6) return false;

            var car = await _repository.Get(id);

            if (car == null) return false;

            car.Make = carModel.Make;
            car.Model = carModel.Model;
            car.Color = carModel.Color;
            car.Plate = carModel.Plate;
            car.MakeDate = carModel.Date;

            await _repository.Update(car);

            return true;
        }

        public async Task<bool> Delete(Guid id)
        {
            var deleteProduct = await _repository.Get(id);

            if (deleteProduct == null) return false;

            await _repository.Delete(deleteProduct);

            return true;
        }

    }
}
