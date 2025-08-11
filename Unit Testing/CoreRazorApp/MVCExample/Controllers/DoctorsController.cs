using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using MVCExample.Data;
using MVCExample.Models;

namespace MVCExample.Controllers
{
    public class DoctorsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DoctorsController(ApplicationDbContext context) // Constructor to initialize the context
        {
            _context = context; // Assigning the injected context to the private field
        }

        //to display the list of doctors
        public IActionResult Index()
        {
           List<Doctor> dlist = _context.doctors.ToList(); // Fetching all doctors from the database
           return View(dlist); // Returning the list of doctors to the view
            //return View();
        }

        [HttpGet]

        //Action to Entry the Doctors
        public IActionResult Show() //
        {
            return View();
        }
        [HttpPost]
        public IActionResult Show(string DocName, string Specialization, string PhoneNumber)
        {
            Doctor d = new Doctor(); // Create a new instance of Doctor
            d.DocName = DocName; // Set the DocName property
            d.Specialization = Specialization; // Set the Specialization property
            d.PhoneNumber = PhoneNumber; // Set the PhoneNumber property
            _context.doctors.Add(d); // Add the doctor to the context
            _context.SaveChanges(); // Save changes to the database
            return RedirectToAction("Index"); // Redirect to the Index action after creation
        }

        [HttpGet]
        public IActionResult Edit(int Id)
        {
            if (Id == null)
                return NotFound(); // If id is null, return NotFound
            Doctor d = _context.doctors.Find(Id); // Find the doctor by id
            return View(d); // Return the doctor to the view for editing
        }

        [HttpPost]
        public IActionResult Edit(Doctor d)
        {
            _context.doctors.Update(d); // Update the doctor in the context
            _context.SaveChanges(); // Save changes to the database
            return RedirectToAction("Index"); // Redirect to the Index action after editing
        }

        // Action to delete a doctor directly from the database without confirmation
        public IActionResult Delete(int Id)
        {
            return View(_context.doctors.Find(Id)); // Find the patient by id and return the view
        }

        [HttpPost]
        public IActionResult Delete(Doctor d)
        {
            _context.doctors.Remove(d); // Remove the doctor from the context
            _context.SaveChanges(); // Save changes to the database
            return RedirectToAction("Index"); // Redirect to the Index action after deletion
        }
    }
}
