using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SecureLoginAndRoleBaseApp.Models;
using System.Diagnostics;

namespace SecureLoginAndRoleBaseApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        public IActionResult AdminDashboard()
        {
            ViewBag.Message = "Welcome, Admin! You have access to the Admin Dashboard.";
            return View();
        }

        [Authorize(Roles = "User")]
        public IActionResult UserProfile()
        {
            ViewBag.Message = "Welcome, User! Here is your profile information.";
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
