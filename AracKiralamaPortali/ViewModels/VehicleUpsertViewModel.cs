using System.ComponentModel.DataAnnotations;

namespace CarRentalPortal.ViewModels
{
    public class VehicleUpsertViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter the vehicle make.")]
        [StringLength(50, ErrorMessage = "Make cannot be longer than 50 characters!")]
        [Display(Name = "Make")]
        public string Make { get; set; } 

        [Required(ErrorMessage = "Please enter the vehicle model.")]
        [StringLength(50, ErrorMessage = "Model cannot be longer than 50 characters!")]
        [Display(Name = "Model")]
        public string Model { get; set; }

        [Required(ErrorMessage = "Please enter the model year.")]
        [Range(1990, 2100, ErrorMessage = "Model year must be between 1990 and 2100!")]
        [Display(Name = "Model Year")]
        public int ModelYear { get; set; } 

        [Required(ErrorMessage = "Please enter the license plate information.")]
        [StringLength(15, ErrorMessage = "License plate cannot be longer than 15 characters!")]
        [Display(Name = "License Plate")]
        public string LicensePlate { get; set; } 

        [Required(ErrorMessage = "Please enter the daily rental rate.")]
        [Range(1.0, 100000.0, ErrorMessage = "Rate must be between 1 TL and 100000 TL!")]
        [Display(Name = "Daily Rate (TL)")]
        public decimal DailyRate { get; set; } 

        [Display(Name = "Description (Optional)")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; } 

        [Display(Name = "Currently Rented?")]
        public bool IsRented { get; set; } = false; 
    }
}