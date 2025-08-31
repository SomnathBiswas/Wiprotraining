using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AdvancedRazorPagesApp.Models;
using System.Collections.Generic;

namespace AdvancedRazorPagesApp.Pages.Products
{
    public class CreateModel : PageModel
    {
        [BindProperty]
        public Product Product { get; set; }

        [BindProperty]
        public List<Category> AvailableCategories { get; set; } = new()
        {
            new Category{ CategoryID=1, CategoryName="Electronics"},
            new Category{ CategoryID=2, CategoryName="Fashion"},
            new Category{ CategoryID=3, CategoryName="Books"}
        };

        public void OnGet()
        {
            Product = new Product();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            TempData["Message"] = "Product Created!";
            return RedirectToPage("Index");
        }
    }
}
