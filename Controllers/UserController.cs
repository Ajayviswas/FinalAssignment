using FinalAssignment.Data;
using FinalAssignment.Models;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.EntityFrameworkCore;

namespace FinalAssignment.Controllers
{
    public class UserController : ControllerBase
    {
        private readonly CarDbContext _context;
        private readonly IConfiguration _configuration;

        public UserController(CarDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] User user)
        {
            if (await _context.Users.AnyAsync(u => u.Email == user.Email))
                return BadRequest("User already exists");

            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return Ok("User registered successfully");
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] User loginData)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u =>
                u.Email == loginData.Email && u.Password == loginData.Password);

            if (user == null)
                return Unauthorized("Invalid credentials");

            // Use IConfiguration to retrieve the JWT settings
            var token = Helper.JwtHelper.GenerateToken(
                user.Email,
                user.Role,
                _configuration["Jwt:Key"],
                _configuration["Jwt:Issuer"],
                _configuration["Jwt:Audience"]
            );

            return Ok(new { Token = token });
        }
    }
}
