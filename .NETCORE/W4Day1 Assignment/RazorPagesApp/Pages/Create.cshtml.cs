using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesApp.Models;
using RazorPagesApp.Services;

namespace RazorPagesApp.Pages.Items
{
    public class CreateModel : PageModel
    {
        private readonly IItemService _service;
        [BindProperty]
        public Item NewItem { get; set; }
        public CreateModel(IItemService service) => _service = service;
        public void OnGet() { }
        public IActionResult OnPost() {
            if (!ModelState.IsValid) return Page();
            _service.Add(NewItem);
            return RedirectToPage("/Items/Index");
        }
    }
}
