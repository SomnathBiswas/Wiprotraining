using SecureUserManagement.Data;
using SecureUserManagement.Models;
using System;
using System.Security.Cryptography;
using System.Text;

namespace SecureUserManagement.Services
{
    public class AuthService
    {
        //private readonly AppicationDbContext _context;
        private readonly ApplicationDbContext _context;


        public AuthService(ApplicationDbContext context)
        {
            _context = context;
        }

        public string HashPassword(string password)
        {
            using SHA256 sha256 = SHA256.Create();
            var bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
            return Convert.ToBase64String(bytes);
        }

        public bool Register(string username, string password)
        {
            if (_context.Users.Any(u => u.Username == username)) return false;

            var hashedPassword = HashPassword(password);
            var newUser = new User { Username = username, HashedPassword = hashedPassword };
            _context.Users.Add(newUser);
            _context.SaveChanges();
            return true;
        }

        public bool Authenticate(string username, string password)
        {
            var user = _context.Users.FirstOrDefault(u => u.Username == username);
            if (user == null) return false;
            return user.HashedPassword == HashPassword(password);
        }
    }
}
