using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using MVCExample.Data;
using MVCExample.Models;
namespace MVCExample.Controllers
{
    public class PatientsController : Controller
    {   private readonly ApplicationDbContext _context; // Injecting the ApplicationDbContext to interact with the database
        public PatientsController(ApplicationDbContext context) // Constructor to initialize the context
        {
            _context = context; // Assigning the injected context to the private field
        }

        //to display the list of patients 
        public IActionResult Index()
        {
            List<Patient> plist = _context.patients.ToList(); // Fetching all patients from the database
            return View(plist); // Returning the list of patients to the view
            
        }
        
        [HttpGet]
        public IActionResult Create() // Action to display the form for creating a new patient
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(string Name, string Allergies, string Number)
        {
            // Here you would typically save the patient to a database
            Patient p = new Patient(); // Create a new instance of Patient
            p.Name = Name; // Set the Name property
            p.Allergies = Allergies;
            p.Number = Number;// Set the Allergies property
            _context.patients.Add(p); // Add the patient to the context
            _context.SaveChanges(); // Save changes to the database
            return RedirectToAction("Index"); // Redirect to the Index action after creation

        }

        public IActionResult Edit(int Id)
        {
            if(Id == null)
            
                return NotFound(); // If id is null, return NotFound
            Patient p = _context.patients.Find(Id);
            return View(p);// Find the patient by id

        }

        [HttpPost]
        public IActionResult Edit(Patient p)
        {
            _context.patients.Update(p); // Update the patient in the context
            _context.SaveChanges(); // Save changes to the database
            return RedirectToAction("Index"); // Redirect to the Index action after editing
        }

        // Action to delete a directly from the database without confirmation
        //public IActionResult Delete(int Id)
        //{
        //    _context.patients.Remove(_context.patients.Find(Id));
        //    _context.SaveChanges(); // Remove the patient from the context
        //    return RedirectToAction("Index"); // Redirect to the Index action after deletion
        //}

        // Action to delete a patient with confirmation

        public IActionResult Delete(int Id) 
            {
                return View(_context.patients.Find(Id)); // Find the patient by id and return the view
            }


        [HttpPost,ActionName("DeleteConfirmed")] // This attribute specifies that this action is called when the form is submitted
        public IActionResult DeleteConfirmed(int Id)
        {
            _context.patients.Remove(_context.patients.Find(Id));
            _context.SaveChanges();
            return RedirectToAction("Index"); // Redirect to the Index action after deletion
        }
    }
}
