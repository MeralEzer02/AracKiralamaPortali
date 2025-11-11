using System.ComponentModel.DataAnnotations;

namespace AracKiralamaPortali.ViewModels
{
    public class VehicleUpsertViewModel 
    {
        public int Id { get; set; } 

        [Required(ErrorMessage = "Lütfen araç markasını giriniz.")]
        [StringLength(50, ErrorMessage = "Marka 50 karakterden uzun olamaz!")] 
        [Display(Name = "Marka")]
        public string Marka { get; set; }

        [Required(ErrorMessage = "Lütfen araç modelini giriniz.")]
        [StringLength(50, ErrorMessage = "Model 50 karakterden uzun olamaz!")]
        [Display(Name = "Model")]
        public string Model { get; set; }

        [Required(ErrorMessage = "Lütfen Model Yılını giriniz.")]
        [Range(1990, 2100, ErrorMessage = "Model yılı 1990 ile 2100 arasında olmalıdır!")] 
        [Display(Name = "Model Yılı")]
        public int ModelYili { get; set; }

        [Required(ErrorMessage = "Lütfen plaka bilgisini giriniz.")]
        [StringLength(15, ErrorMessage = "Plaka 15 karakterden uzun olamaz!")]
        [Display(Name = "Plaka")]
        public string Plaka { get; set; }

        [Required(ErrorMessage = "Lütfen günlük kira ücretini giriniz.")]
        [Range(1.0, 100000.0, ErrorMessage = "Ücret 1 TL ile 100000 TL arasında olmalıdır!")]
        [Display(Name = "Günlük Kira Ücreti (TL)")]
        public decimal GunlukKiraUcreti { get; set; }

        [Display(Name = "Açıklama (Opsiyonel)")]
        [DataType(DataType.MultilineText)] 
        public string Aciklama { get; set; } 

        [Display(Name = "Şu Anda Kirada Mı?")]
        public bool KiradaMi { get; set; } = false; 
    }
}