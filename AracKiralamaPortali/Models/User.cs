using System.ComponentModel.DataAnnotations;

namespace CarRentalPortal.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Email { get; set; }

        [Required]
        public string PasswordHash { get; set; } 

        [Required]
        public string Role { get; set; } 

        public DateTime RegistrationDate { get; set; } = DateTime.Now;
    }
}