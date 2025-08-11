﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Collections.Generic;
using System.Linq;

namespace LibrarySystem
{
    public class Library
    {
        public List<Book> Books { get; }
        public List<Borrower> Borrowers { get; }

        public Library()
        {
            Books = new List<Book>();
            Borrowers = new List<Borrower>();
        }

        public void AddBook(Book book) => Books.Add(book);

        public void RegisterBorrower(Borrower borrower) => Borrowers.Add(borrower);

        public void BorrowBook(string isbn, string libraryCardNumber)
        {
            var book = Books.FirstOrDefault(b => b.ISBN == isbn && !b.IsBorrowed);
            var borrower = Borrowers.FirstOrDefault(b => b.LibraryCardNumber == libraryCardNumber);

            if (book != null && borrower != null)
                borrower.BorrowBook(book);
        }

        public void ReturnBook(string isbn, string libraryCardNumber)
        {
            var book = Books.FirstOrDefault(b => b.ISBN == isbn);
            var borrower = Borrowers.FirstOrDefault(b => b.LibraryCardNumber == libraryCardNumber);

            if (book != null && borrower != null && borrower.BorrowedBooks.Contains(book))
                borrower.ReturnBook(book);
        }

        public List<Book> ViewBooks() => Books;

        public List<Borrower> ViewBorrowers() => Borrowers;
    }
}

