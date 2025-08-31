using Microsoft.AspNetCore.Mvc;

namespace ECommerceApp.Controllers
{
    public class CheckoutController : Controller
    {
        // Mock user login status
        private bool IsLoggedIn => false;

        public IActionResult Index()
        {
            if (!IsLoggedIn)
                return View("Login"); // Redirect guest to login

            return View("Index"); // Show checkout page
        }
    }
}
