using System.ComponentModel.DataAnnotations;

namespace AracKiralamaPortali.ViewModels 
{
    public class AracListViewModel
    {
        public int Id { get; set; } 

        [Display(Name = "Marka")] 
        public string Marka { get; set; } 

        [Display(Name = "Model")]
        public string Model { get; set; }

        [Display(Name = "Model Yılı")]
        public int ModelYili { get; set; } 

        [Display(Name = "Plaka")]
        public string Plaka { get; set; } 

        [Display(Name = "Kira Ücreti (Günlük)")]
        [DataType(DataType.Currency)] 
        public decimal GunlukKiraUcreti { get; set; } 

        [Display(Name = "Durum")]
        public bool KiradaMi { get; set; } 
        public string DurumMetni => KiradaMi ? "Kirada" : "Müsait";
    }
}