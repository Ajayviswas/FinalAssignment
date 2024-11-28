using FinalAssignment.Models;
using Microsoft.EntityFrameworkCore;

namespace FinalAssignment.Data
{
    public class CarDbContext : DbContext
    {
        public CarDbContext(DbContextOptions<CarDbContext> options) : base(options) 
        {
            
        }

        public DbSet<Car>Cars { get; set; }
        public DbSet<User>Users { get; set; }
    }
}
