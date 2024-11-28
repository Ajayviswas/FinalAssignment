
using FinalAssignment.Data;
using FinalAssignment.Models;
using Microsoft.EntityFrameworkCore;

namespace FinalAssignment.Repositories
{
    public class CarRepository : ICarRepository
    {
        private readonly CarDbContext _context;

        public CarRepository(CarDbContext context)
        {
            _context = context;
        }

        public async Task<List<Car>> GetAvailableCars() =>
            await _context.Cars.Where(c => c.IsAvailable).ToListAsync();

        public async Task AddCar(Car car)
        {
            _context.Cars.Add(car);
            await _context.SaveChangesAsync();
        }

        public async Task<Car> GetCarById(int id) =>
            await _context.Cars.FindAsync(id);

        public async Task UpdateCarAvailability(int id, bool isAvailable)
        {
            var car = await GetCarById(id);
            if (car != null)
            {
                car.IsAvailable = isAvailable;
                await _context.SaveChangesAsync();
            }
        }
    }
}
