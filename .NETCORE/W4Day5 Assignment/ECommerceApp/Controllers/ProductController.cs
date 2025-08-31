using Microsoft.AspNetCore.Mvc;

namespace ECommerceApp.Controllers
{
    public class ProductsController : Controller
    {
        public IActionResult Details(string category, int id)
        {
            return Content($"Product Details: Category={category}, ID={id}");
        }

        public IActionResult Filter(string category, string? priceRange)
        {
            return Content($"Filtering products in {category} with price range {priceRange}");
        }
    }
}
