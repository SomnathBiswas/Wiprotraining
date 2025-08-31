using Microsoft.AspNetCore.Mvc;
using BookStoreApp.Models;
using BookStoreApp.Data;

namespace BookStoreApp.Controllers
{
    public class BookController : Controller
    {
        private readonly BookDAL _dal;

        public BookController(IConfiguration config)
        {
            _dal = new BookDAL(config.GetConnectionString("DefaultConnection"));
        }

        public IActionResult Index()
        {
            var books = _dal.GetBooks();
            return View(books);
        }

        public IActionResult Create() => View();

        [HttpPost]
        public IActionResult Create(Book book)
        {
            _dal.AddBook(book);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var book = _dal.GetBooks().FirstOrDefault(b => b.Id == id);
            return View(book);
        }

        [HttpPost]
        public IActionResult Edit(Book book)
        {
            _dal.UpdateBook(book);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            _dal.DeleteBook(id);
            return RedirectToAction("Index");
        }
    }
}
