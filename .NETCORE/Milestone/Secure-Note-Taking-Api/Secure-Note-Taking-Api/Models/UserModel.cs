using System.ComponentModel.DataAnnotations;

namespace Secure_Note_Taking_Api.Models
{
    public class UserModel
    {
        public int Id { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        public string PasswordHash { get; set; }
    }
}
