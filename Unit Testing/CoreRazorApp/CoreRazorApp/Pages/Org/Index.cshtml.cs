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
    public class IndexModel : PageModel
    {
        private readonly CoreRazorApp.Models.OrgContext _context;

        public IndexModel(CoreRazorApp.Models.OrgContext context)
        {
            _context = context;
        }

        public IList<Organization> Organization { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Organization = await _context.Organizations.ToListAsync();
        }
    }
}
