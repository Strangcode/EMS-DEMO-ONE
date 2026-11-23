using System.ComponentModel.DataAnnotations;

namespace practiceproject.Models
{
    public class UserRegistration
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string? Email { get; set; }

        public string? PasswordHash { get; set; }

        public string? Role { get; set; } = "User"; // Default role is "User"

    }
}
