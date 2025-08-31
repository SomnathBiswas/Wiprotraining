using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace SecureLoginAndRoleBaseApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> _UManager;
        private readonly SignInManager<IdentityUser> _SignManager;

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _UManager = userManager;
            _SignManager = signInManager;
        }

        [HttpGet]
        public IActionResult Login()
        {
            if (User.IsInRole("Admin"))
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return RedirectToAction("UserProfile", "Home");
            }
        }
        [HttpPost]

        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                ViewBag.Error = "Please enter username and password";
                return View();
            }
            var user = await _UManager.FindByNameAsync(username);
            if (user == null)
            {
                ViewBag.Error = "Invalid credentials";
                return View();
            }
            var result = await _SignManager.PasswordSignInAsync(user, password, false, false);

            if (result.Succeeded)
            {
                if (username == "admin")
                {
                    if (!await _UManager.IsInRoleAsync(user, "Admin"))
                    {
                        await _UManager.AddToRoleAsync(user, "Admin");
                    }
                    return RedirectToAction("AdminDashboard", "Home");
                }
                else
                {
                    if (!await _UManager.IsInRoleAsync(user, "User"))
                    {
                        await _UManager.AddToRoleAsync(user, "User");
                    }
                    return RedirectToAction("UserProfile", "Home");
                }
            }

            ViewBag.Error = "Wrong Credentials";
            return View();
        }

        [HttpPost]

        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await _SignManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

    }

   
}
