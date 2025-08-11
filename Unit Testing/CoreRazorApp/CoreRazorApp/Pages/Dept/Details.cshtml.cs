using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CoreRazorApp.Models;

namespace CoreRazorApp.Pages.Dept
{
    public class DetailsModel : PageModel
    {
        private readonly CoreRazorApp.Models.OrgContext _context;

        public DetailsModel(CoreRazorApp.Models.OrgContext context)
        {
            _context = context;
        }

        public Department Department { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var department = await _context.Departments.FirstOrDefaultAsync(m => m.Id == id);
            if (department == null)
            {
                return NotFound();
            }
            else
            {
                Department = department;
            }
            return Page();
        }
    }
}
