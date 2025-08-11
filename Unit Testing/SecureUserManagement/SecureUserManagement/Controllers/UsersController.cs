using Microsoft.AspNetCore.Mvc;
using SecureUserManagement.Data;
using SecureUserManagement.Models;
using SecureUserManagement.Service;

namespace SecureUserManagement.Controllers
{
    public class UsersController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly SecurityService _security;
        private readonly ILogger<UsersController> _logger;
        private const string encryptionKey = "MySuperSecretKey";

        public UsersController(ApplicationDbContext context, ILogger<UsersController> logger)
        {
            _context = context;
            _security = new SecurityService();
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Register() => View();

        [HttpPost]
        public IActionResult Register(string username, string password, string email)
        {
            try
            {
                var hashedPassword = _security.HashPassword(password);
                var encryptedEmail = _security.Encrypt(email, encryptionKey);

                var user = new User { Username = username, HashedPassword = hashedPassword, EncryptedEmail = encryptedEmail };
                _context.Users.Add(user);
                _context.SaveChanges();

                _logger.LogInformation($"User {username} registered at {DateTime.Now}");
                return RedirectToAction("Login");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Registration failed");
                return View();
            }
        }

        [HttpGet]
        public IActionResult Login() => View();

        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            try
            {
                var hashedPassword = _security.HashPassword(password);
                var user = _context.Users.FirstOrDefault(u => u.Username == username && u.HashedPassword == hashedPassword);

                if (user != null)
                {
                    _logger.LogInformation($"User {username} logged in at {DateTime.Now}");
                    ViewBag.Message = "Login successful!";
                    return View("Success", user);
                }

                ViewBag.Message = "Invalid credentials.";
                return View();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Login failed");
                return View();
            }
        }
    }
}
