
using System.ComponentModel.DataAnnotations;

namespace Secure_Note_Taking_Api.DataTranferObjects
{
    public class Login
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
