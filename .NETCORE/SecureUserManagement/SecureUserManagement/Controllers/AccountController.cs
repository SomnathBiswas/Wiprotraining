using Microsoft.AspNetCore.Mvc;
using SecureUserManagement.Services;

namespace SecureUserManagement.Controllers
{
    public class AccountController : Controller
    {
        private readonly AuthService _authService;
        private readonly EncryptionService _encryptionService;
        private readonly LoggerService _logger;

        public AccountController(AuthService authService, EncryptionService encryptionService, LoggerService logger)
        {
            _authService = authService;
            _encryptionService = encryptionService;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Register() => View();

        [HttpPost]
        public IActionResult Register(string username, string password, string sensitiveData)
        {
            try
            {
                if (_authService.Register(username, password))
                {
                    var encryptedData = _encryptionService.Encrypt(sensitiveData);
                    _logger.LogInfo($"User {username} registered successfully.");
                    return RedirectToAction("Login");
                }
                ViewBag.Error = "Username already exists.";
                return View();
            }
            catch (Exception ex)
            {
                _logger.LogError("Error during registration", ex);
                ViewBag.Error = "Something went wrong.";
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
                if (_authService.Authenticate(username, password))
                {
                    _logger.LogInfo($"User {username} logged in successfully.");
                    return RedirectToAction("Index", "Home");
                }
                ViewBag.Error = "Invalid credentials.";
                return View();
            }
            catch (Exception ex)
            {
                _logger.LogError("Error during login", ex);
                ViewBag.Error = "Something went wrong.";
                return View();
            }
        }
    }
}
