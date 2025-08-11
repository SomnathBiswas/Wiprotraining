using System.ComponentModel.DataAnnotations;

namespace SecureUserManagement.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string HashedPassword { get; set; }

        public string? EncryptedSensitiveData { get; set; }
    }
}
