using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AdvancedRazorPagesApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace AdvancedRazorPagesApp.Pages.Products
{
    [BindProperties]
    public class DetailsModel : PageModel
    {
        public Product Product { get; set; } = new Product();

        public IActionResult OnGet(int id)
        {
            var products = new List<Product>
            {
                new Product { ProductID=1, Name="Laptop", Description="High performance laptop",
                    Categories=new List<Category>{ new Category{CategoryID=1, CategoryName="Electronics"}}},
                new Product { ProductID=2, Name="Shoes", Description="Running shoes",
                    Categories=new List<Category>{ new Category{CategoryID=2, CategoryName="Fashion"}}}
            };

            Product = products.FirstOrDefault(p => p.ProductID == id);
            if (Product == null) return NotFound();
            return Page();
        }
    }
}
