using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Collections.Generic;

namespace LibrarySystem
{
    public class Borrower
    {
        public string Name { get; }
        public string LibraryCardNumber { get; }
        public List<Book> BorrowedBooks { get; }

        public Borrower(string name, string cardNumber)
        {
            Name = name;
            LibraryCardNumber = cardNumber;
            BorrowedBooks = new List<Book>();
        }

        public void BorrowBook(Book book)
        {
            BorrowedBooks.Add(book);
            book.Borrow();
        }

        public void ReturnBook(Book book)
        {
            BorrowedBooks.Remove(book);
            book.Return();
        }
    }
}

