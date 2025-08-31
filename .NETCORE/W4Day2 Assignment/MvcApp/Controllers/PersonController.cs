using Microsoft.AspNetCore.Mvc;
using MvcApp.Models;

namespace MvcApp.Controllers
{
    public class PersonController : Controller
    {
        // GET: /Person
        public IActionResult Index()
        {
            return View();
        }

        // GET: /Person/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: /Person/Create
        [HttpPost]
        public IActionResult Create(Person person)
        {
            if (ModelState.IsValid)
            {
                // Redirect to details page with submitted data
                return View("Details", person);
            }
            return View(person);
        }

        // GET: /Person/Details
        public IActionResult Details(Person person)
        {
            return View(person);
        }
    }
}
