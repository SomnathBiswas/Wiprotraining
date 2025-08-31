using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using BookStoreApp.Models;

namespace BookStoreApp.Data
{
    public class BookDAL
    {
        private readonly string _connectionString;

        public BookDAL(string connectionString)
        {
            _connectionString = connectionString;
        }

        // READ (using SqlDataReader)
        public List<Book> GetBooks()
        {
            var books = new List<Book>();
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM Books", con);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    books.Add(new Book
                    {
                        Id = (int)reader["Id"],
                        Title = reader["Title"].ToString(),
                        Author = reader["Author"].ToString(),
                        Price = (decimal)reader["Price"],
                        Quantity = (int)reader["Quantity"]
                    });
                }
            }
            return books;
        }

        // CREATE (parameterized query - prevents SQL injection)
        public void AddBook(Book book)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO Books (Title, Author, Price, Quantity) VALUES (@Title, @Author, @Price, @Quantity)", con);
                cmd.Parameters.AddWithValue("@Title", book.Title);
                cmd.Parameters.AddWithValue("@Author", book.Author);
                cmd.Parameters.AddWithValue("@Price", book.Price);
                cmd.Parameters.AddWithValue("@Quantity", book.Quantity);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // UPDATE
        public void UpdateBook(Book book)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("UPDATE Books SET Title=@Title, Author=@Author, Price=@Price, Quantity=@Quantity WHERE Id=@Id", con);
                cmd.Parameters.AddWithValue("@Id", book.Id);
                cmd.Parameters.AddWithValue("@Title", book.Title);
                cmd.Parameters.AddWithValue("@Author", book.Author);
                cmd.Parameters.AddWithValue("@Price", book.Price);
                cmd.Parameters.AddWithValue("@Quantity", book.Quantity);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // DELETE
        public void DeleteBook(int id)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM Books WHERE Id=@Id", con);
                cmd.Parameters.AddWithValue("@Id", id);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
