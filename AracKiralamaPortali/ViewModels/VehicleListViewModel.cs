using System.ComponentModel.DataAnnotations;

namespace CarRentalPortal.ViewModels
{
    public class VehicleListViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Make")]
        public string Make { get; set; } 

        [Display(Name = "Model")]
        public string Model { get; set; }

        [Display(Name = "Model Year")]
        public int ModelYear { get; set; } 

        [Display(Name = "License Plate")]
        public string LicensePlate { get; set; } 

        [Display(Name = "Daily Rate")]
        [DataType(DataType.Currency)]
        public decimal DailyRate { get; set; }

        [Display(Name = "Status")]
        public bool IsRented { get; set; } 

        public string StatusText => IsRented ? "Rented" : "Available";
    }
}