using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SecureLoginApp.Models;
using SecureLoginApp.ViewModels;

namespace SecureLoginApp.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        public AdminController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> Dashboard()
        {
            var users = _userManager.Users.ToList();
            var model = new List<AdminUserViewModel>();
            foreach (var u in users)
            {
                var roles = await _userManager.GetRolesAsync(u);
                model.Add(new AdminUserViewModel
                {
                    Username = u.UserName,
                    Email = u.Email,
                    Roles = string.Join(", ", roles)
                });
            }
            ViewBag.Message = TempData["Message"];
            return View(model);
        }
    }
}
