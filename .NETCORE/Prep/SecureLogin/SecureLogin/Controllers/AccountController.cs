using Microsoft.AspNetCore.Mvc;

namespace SecureLogin.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public IActionResult Login()
        {
            return RedirectToPage("/Account/Login");
        }

        [HttpGet]
        public IActionResult Register()
        {
            return RedirectToPage("/Account/Register");
        }

        [HttpPost]

        [ValidateAntiForgeryToken]
        public IActionResult Logout()
        {
            return RedirectToPage("/Account/Logout");
        }
    }
}
