using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesApp.Services;
using RazorPagesApp.Models;
using System.Collections.Generic;

namespace RazorPagesApp.Pages.Items
{
    public class IndexModel : PageModel
{
    private readonly IItemService _service;
    public IEnumerable<Item> Items { get; private set; }
        public IndexModel(IItemService service)
        { _service = service; }
    public void OnGet() => Items = _service.GetAll();
}
}


