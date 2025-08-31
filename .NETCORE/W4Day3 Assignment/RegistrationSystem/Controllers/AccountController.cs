using Microsoft.AspNetCore.Mvc;
using RegistrationSystem.Models;

namespace RegistrationSystem.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Register() => View();

        [HttpPost]
        public IActionResult Register(UserRegistration model)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Success");
            }

            return View(model);
        }

        public IActionResult Success()
        {
            return View();
        }
    }
}
