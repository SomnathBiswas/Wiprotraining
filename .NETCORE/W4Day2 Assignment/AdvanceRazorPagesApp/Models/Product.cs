using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AdvancedRazorPagesApp.Models
{
    public class Product
    {
        public int ProductID { get; set; }

        [Required, StringLength(100)]
        public string Name { get; set; } = string.Empty;

        [Required, StringLength(500)]
        public string Description { get; set; } = string.Empty;

        public List<Category> Categories { get; set; } = new();
    }
}
