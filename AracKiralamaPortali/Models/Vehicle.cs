using System.ComponentModel.DataAnnotations;

namespace CarRentalPortal.Models
{
    public class Vehicle
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "The vehicle make is required.")]
        [MaxLength(50)]
        public string Make { get; set; }

        [Required(ErrorMessage = "The model is required.")]
        [MaxLength(50)]
        public string Model { get; set; }

        [Range(1900, 2100, ErrorMessage = "Please enter a valid model year.")]
        public int ModelYear { get; set; }


        [Required]
        [MaxLength(15)]
        public string LicensePlate { get; set; }

        [Range(0.01, 10000, ErrorMessage = "Daily rental rate must be a valid value.")]
        public decimal DailyRate { get; set; }

        public string Description { get; set; }

        public bool IsRented { get; set; } = false;
    }
}