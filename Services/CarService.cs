using FinalAssignment.Models;
using FinalAssignment.Repositories;

namespace FinalAssignment.Services
{
    public class CarService
    {
        private readonly ICarRepository _repository;

        public CarService(ICarRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Car>> GetAvailableCars() => await _repository.GetAvailableCars();

        public async Task RentCar(int carId)
        {
            await _repository.UpdateCarAvailability(carId, false);
        }

        public async Task AddCar(Car car)
        {
            await _repository.AddCar(car);
        }
    }
}
