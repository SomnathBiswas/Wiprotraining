using System.ComponentModel.DataAnnotations;

namespace Secure_Note_Taking_Api.DataTranferObjects
{
    public class Register
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
