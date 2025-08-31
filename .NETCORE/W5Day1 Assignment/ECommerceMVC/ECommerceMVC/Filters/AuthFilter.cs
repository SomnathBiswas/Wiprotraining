using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
namespace ECommerceMVC.Filters
{
    public class AuthFilter : IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var isLoggedIn = context.HttpContext.Session.GetString("User") != null;
            if (!isLoggedIn)
            {
                context.Result = new RedirectToActionResult("Login", "Account", null);
            }
        }
    }
}
