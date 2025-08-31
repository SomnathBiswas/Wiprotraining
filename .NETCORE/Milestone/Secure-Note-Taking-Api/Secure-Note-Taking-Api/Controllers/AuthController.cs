using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Secure_Note_Taking_Api.Data;
using Secure_Note_Taking_Api.Models;
using Secure_Note_Taking_Api.Services;
using Secure_Note_Taking_Api.DataTranferObjects;


namespace Secure_Note_Taking_Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly SecureNoteDbContext _db;
        private readonly JwtService _jwt;
        private readonly IPasswordHasher<UserModel> _passwordHasher;

        public AuthController(SecureNoteDbContext db, JwtService jwt, IPasswordHasher<UserModel> passwordHasher)
        {
            _db = db;
            _jwt = jwt;
            _passwordHasher = passwordHasher;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] Register dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var exist = await _db.Users.AnyAsync(u => u.UserName.ToLower() == dto.UserName.ToLower());
            if (exist) return BadRequest(new { message = "Username already exists." });

            if (dto.Password.Length < 8 || !dto.Password.Any(char.IsUpper) ||
            !dto.Password.Any(char.IsLower) || !dto.Password.Any(char.IsDigit) ||
                !dto.Password.Any(ch => "!@#$%^&*".Contains(ch)))

            {
                return BadRequest(new { message = "Password must be at least 8 characters" });
            }
            var user = new UserModel { UserName = dto.UserName };
            user.PasswordHash = _passwordHasher.HashPassword(user, dto.Password);

            _db.Users.Add(user);
            await _db.SaveChangesAsync();

            return Ok(new { message = "User registered successfully! Please log in." });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] Login dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var User = await _db.Users.FirstOrDefaultAsync(u => u.UserName == dto.UserName);
            if (User == null) return Unauthorized(new { message = "Invalid credentials." });

            var verify = _passwordHasher.VerifyHashedPassword(User, User.PasswordHash, dto.Password);
            if (verify == PasswordVerificationResult.Failed) return Unauthorized(new { message = "Invalid credentials." });

            var token = _jwt.GToken(User);

            return Ok(new
            {
                token,
                expires_in = _jwt.ExpiryTime,
                user = new { username = User.UserName }
            });
        }
    }
}
