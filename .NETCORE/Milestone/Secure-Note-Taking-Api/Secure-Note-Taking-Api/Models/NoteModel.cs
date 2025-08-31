using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Secure_Note_Taking_Api.Models
{
    public class NoteModel
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; } = string.Empty;
       public string Content { get; set; } = string.Empty;

        [ForeignKey("User")]
        public int UserId { get; set; }
    }
}
