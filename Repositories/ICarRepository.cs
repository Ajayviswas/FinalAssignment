using FinalAssignment.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FinalAssignment.Repositories
{
    public interface ICarRepository
    {
        Task<List<Car>> GetAvailableCars();
        Task AddCar(Car car);
        Task<Car> GetCarById(int id);
        Task UpdateCarAvailability(int id, bool isAvailable);
    }
}
