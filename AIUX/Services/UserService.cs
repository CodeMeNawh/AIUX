using AIUX.Data;
using AIUX.DTOs;
using AIUX.Models;
using AIUX.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AIUX.Services
{
    public class UserService : IUserService
    {
        private readonly AppDbContext _context;
        private readonly IConfiguration _configuration;

        public UserService(AppDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }
        public async Task<bool> IsTakenEmailAsync(string email)
        {
            return await _context.Users.AnyAsync(u => u.Email == email);

        }

        public async Task<string?> LoginAsync(LoginUserDto dto)
        { // 1️⃣ Find the user by email in the database
            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.Email == dto.Email);

            if (user == null)
                return null; // No user with this email

            // 2️⃣ Check if the password is correct
            // BCrypt.Verify compares the plain password with the hashed one in the database
            if (!BCrypt.Net.BCrypt.Verify(dto.Password, user.PasswordHash))
                return null; // Password incorrect

            // 3️⃣ Create the JWT token
            // This token will be sent to the client to authorize future requests
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]!); // secret key from appsettings.json

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
            // Claims are just info about the user inside the token
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Email, user.Email)
                }),
                Expires = DateTime.UtcNow.AddHours(2), // token valid for 2 hours
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),     // use our secret key
                    SecurityAlgorithms.HmacSha256Signature) // algorithm to sign the token
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            // 4️⃣ Return the token as a string
            return tokenHandler.WriteToken(token);
        }

        public async Task RegisterAsync(RegisterUserDto dto)
        {
            var hashedPassword = BCrypt.Net.BCrypt.HashPassword(dto.Password);

            var user = new User
            {
                Email = dto.Email,
                PasswordHash = hashedPassword,
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();
        }
    }
}
