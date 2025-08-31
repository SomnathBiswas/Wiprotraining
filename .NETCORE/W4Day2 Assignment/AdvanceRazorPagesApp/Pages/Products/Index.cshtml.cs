using Microsoft.AspNetCore.Mvc.RazorPages;
using AdvancedRazorPagesApp.Models;
using System.Collections.Generic;

namespace AdvancedRazorPagesApp.Pages.Products
{
    public class IndexModel : PageModel
    {
        public List<Product> Products { get; set; }
        public void OnGet()
        {
            Products = new List<Product>
            {
                new Product {
                    ProductID = 1,
                    Name = "Laptop",
                    Description = "High performance laptop",
                    Categories = new List<Category> {
                        new Category { CategoryID = 1, CategoryName = "Electronics" }
                    }
                },
                new Product {
                    ProductID = 2,
                    Name = "Shoes",
                    Description = "Comfortable running shoes",
                    Categories = new List<Category> {
                        new Category { CategoryID = 2, CategoryName = "Fashion" }
                    }
                }
            };
        }
    }
}
