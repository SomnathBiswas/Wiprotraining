using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CoreRazorApp.Models;

namespace CoreRazorApp.Pages.Emp
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
            
            ViewData["DepartmentId"] = new SelectList(_context.Departments, "Id", "Id");
            return Page();
        }

        [BindProperty]
        public Employee Employee { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Employees.Add(Employee);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
