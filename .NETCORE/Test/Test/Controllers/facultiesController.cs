using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using Test.Data;
using Test.Models;
//using MVCExample.Data;
//using MVCExample.Models;

namespace Test.Controllers
{   
    public class facultiesController : Controller
    {
        private readonly ApplicationDbContext dbContext;
        public facultiesController(ApplicationDbContext context)
        {
            dbContext = context;
        }

        //index
        [HttpGet]
        public IActionResult Index()
        {
            // Fetch all faculty members from the database
           
            List<faculty> flist = dbContext.Faculty.ToList();
            return View(flist);
            //return View();
        }
        //create
        //method type- GET/ post
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(string Name, string Department, string Email, string PhoneNumber)
        {

            { //create - create table database id varchar(50) not null, name varchar(50) not null, department varchar(50) not null, email varchar(50) not null, phoneNumber varchar(15) not null
                faculty f = new faculty();
                f.Name = Name;
                f.Department = Department;
                f.Email = Email;
                f.PhoneNumber = PhoneNumber;
                dbContext.Faculty.Add(f);
                dbContext.SaveChanges();

                // Save the faculty to the database
                // dbContext.Faculties.Add(faculty);
                // dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            
        }
        //edit
        [HttpGet]
        public IActionResult Edit(int id)
        {
            // Fetch the faculty member by ID
            
            if (id == null)
            {
                return NotFound();
            }
            faculty f = dbContext.Faculty.Find(id);
            return View(f);
        }
        [HttpPost]
        public IActionResult Edit(faculty f)
        {
            dbContext.Faculty.Update(f); // Update the patient in the context
            dbContext.SaveChanges(); // Save changes to the database
            return RedirectToAction("Index"); // Redirect to the Index action after editing
        }
        //public IActionResult Delete(int Id)
        //{
        //    dbContext.Faculty.Remove(dbContext.Faculty.Find(Id));
        //   dbContext.SaveChanges(); // Remove the patient from the context
        //    return RedirectToAction("Index"); // Redirect to the Index action after deletion
        //}

        [HttpGet]
        public IActionResult Delete(int Id)
        {
            return View(dbContext.Faculty.Find(Id)); // Find the patient by id and return the view
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int Id)
        {

            dbContext.Faculty.Remove(dbContext.Faculty.Find(Id));// Remove the patient from the context
            dbContext.SaveChanges(); // Save changes to the database
           
            return RedirectToAction("Index"); // Redirect to the Index action after deletion
        }




    }
}
