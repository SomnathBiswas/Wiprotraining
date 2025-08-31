using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Secure_Note_Taking_Api.Models;

namespace Secure_Note_Taking_Api.Services
{
    public class JwtService
    {
        private readonly IConfiguration _configs;
        public int ExpiryTime { get; }

        public JwtService(IConfiguration config)
        {
            _configs = config;
            ExpiryTime = int.Parse(_configs["Jwt:ExpiryTime"] ?? "3600");
        }

        public string GToken(UserModel user)
        {
            var myclaim = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.UserName)
            };

            var newkey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configs["Jwt:Key"]!));
            var newcreds = new SigningCredentials(newkey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                claims: myclaim,
                expires: DateTime.UtcNow.AddSeconds(ExpiryTime),
                signingCredentials: newcreds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
