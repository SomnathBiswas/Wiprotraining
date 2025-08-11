using NUnit.Framework;
using LibrarySystem;

namespace LibrarySystem.Tests
{
    [TestFixture]
    public class LibraryTests
    {
        private Library library;

        [SetUp]
        public void Setup()
        {
            library = new Library();
        }

        [Test]
        public void AddBook_ShouldAddBookToLibrary()
        {
            var book = new Book("Title", "Author", "123");
            library.AddBook(book);
            Assert.Contains(book, library.Books);
        }

        [Test]
        public void RegisterBorrower_ShouldAddBorrowerToLibrary()
        {
            var borrower = new Borrower("Alice", "001");
            library.RegisterBorrower(borrower);
            Assert.Contains(borrower, library.Borrowers);
        }

        [Test]
        public void BorrowBook_ShouldMarkBookAsBorrowed()
        {
            var book = new Book("Title", "Author", "123");
            var borrower = new Borrower("Alice", "001");

            library.AddBook(book);
            library.RegisterBorrower(borrower);
            library.BorrowBook("123", "001");

            Assert.IsTrue(book.IsBorrowed);
            Assert.Contains(book, borrower.BorrowedBooks);
        }

        [Test]
        public void ReturnBook_ShouldMarkBookAsAvailable()
        {
            var book = new Book("Title", "Author", "123");
            var borrower = new Borrower("Alice", "001");

            library.AddBook(book);
            library.RegisterBorrower(borrower);
            library.BorrowBook("123", "001");
            library.ReturnBook("123", "001");

            Assert.IsFalse(book.IsBorrowed);
            Assert.IsFalse(borrower.BorrowedBooks.Contains(book));
        }

        [Test]
        public void ViewBooks_ShouldReturnAllBooks()
        {
            var book = new Book("Title", "Author", "123");
            library.AddBook(book);
            var books = library.ViewBooks();
            Assert.Contains(book, books);
        }

        [Test]
        public void ViewBorrowers_ShouldReturnAllBorrowers()
        {
            var borrower = new Borrower("Alice", "001");
            library.RegisterBorrower(borrower);
            var borrowers = library.ViewBorrowers();
            Assert.Contains(borrower, borrowers);
        }
    }
}
