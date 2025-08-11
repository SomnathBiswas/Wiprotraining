using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CoreRazorApp.Models;

namespace CoreRazorApp.Pages.Org
{
    public class DeleteModel : PageModel
    {
        private readonly CoreRazorApp.Models.OrgContext _context;

        public DeleteModel(CoreRazorApp.Models.OrgContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Organization Organization { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var organization = await _context.Organizations.FirstOrDefaultAsync(m => m.Id == id);

            if (organization == null)
            {
                return NotFound();
            }
            else
            {
                Organization = organization;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var organization = await _context.Organizations.FindAsync(id);
            if (organization != null)
            {
                Organization = organization;
                _context.Organizations.Remove(Organization);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
