using FinalAssignment.Models;
using FinalAssignment.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FinalAssignment.Controllers
{
    public class CarController : ControllerBase
    {
        private readonly CarService _service;

        public CarController(CarService service)
        {
            _service = service;
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAvailableCars()
        {
            var cars = await _service.GetAvailableCars();
            return Ok(cars);
        }

        [HttpPost("post")]
        public async Task<IActionResult> AddCar([FromBody] Car car)
        {
            await _service.AddCar(car);
            return Ok("Car added successfully");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> RentCar(int id)
        {
            await _service.RentCar(id);
            return Ok("Car rented successfully");
        }
    }
}
