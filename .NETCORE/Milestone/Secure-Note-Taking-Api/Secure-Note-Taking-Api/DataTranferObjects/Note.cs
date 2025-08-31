using System.ComponentModel.DataAnnotations;

namespace Secure_Note_Taking_Api.DataTranferObjects
{
    public class Note
    {
        [Required]
        public string Title { get; set; }

        public string Content { get; set; }
    }
}
