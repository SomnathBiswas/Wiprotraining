using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CoreRazorApp.Models;

namespace CoreRazorApp.Pages.Dept
{
    public class CreateModel : PageModel
    {
        private readonly CoreRazorApp.Models.OrgContext _context;

        public CreateModel(CoreRazorApp.Models.OrgContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["OrgId"] = new SelectList(_context.Organizations, "Id", "Name");
            return Page();
        }

        [BindProperty]
        public Department Department { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Departments.Add(Department);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
