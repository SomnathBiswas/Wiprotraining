using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using SecureLoginApp.Models;
using SecureLoginApp.ViewModels;

namespace SecureLoginApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public AccountController(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Login() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            var result = await _signInManager.PasswordSignInAsync(model.Username, model.Password, model.RememberMe, false);

            if (result.Succeeded)
            {
                var user = await _userManager.FindByNameAsync(model.Username);
                var roles = await _userManager.GetRolesAsync(user);

                if (roles.Contains("Admin"))
                {
                    TempData["Message"] = "Welcome, Admin! You have access to the Admin Dashboard.";
                    return RedirectToAction("Dashboard", "Admin");
                }

                if (roles.Contains("User"))
                {
                    TempData["Message"] = "Welcome, User! Here is your profile information.";
                    return RedirectToAction("UserProfile");
                }
            }

            ModelState.AddModelError("", "Invalid login attempt.");
            return View(model);
        }

        [Authorize(Roles = "User")]
        public async Task<IActionResult> UserProfile()
        {
            var user = await _userManager.GetUserAsync(User);
            return View(new UserProfileViewModel
            {
                Username = user.UserName,
                Email = user.Email,
                Message = TempData["Message"] as string ?? ""
            });
        }

        public IActionResult AccessDenied() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
