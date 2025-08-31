using System.Collections.Generic;

namespace OnlineBookstore.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public List<Book> Books { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
