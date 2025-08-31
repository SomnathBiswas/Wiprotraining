using Microsoft.AspNetCore.Mvc;
using ECommerceMVC.Models;

namespace ECommerceMVC.Controllers
{
    public class ProductsController : Controller
    {
        public IActionResult Index()
        {
            var products = new List<Product>
            {
                new Product {Id = 1, Name = "Laptop", Price = 55000},
                new Product {Id = 2, Name = "Phone", Price = 25000}
            };

            return View(products);
        }
    }
}
