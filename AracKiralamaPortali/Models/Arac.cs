using System.ComponentModel.DataAnnotations;

namespace AracKiralamaPortali.Models
{
    public class Arac
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Marka alanı zorunludur.")]
        [MaxLength(50)]
        public string Marka { get; set; }

        [Required(ErrorMessage = "Model alanı zorunludur.")]
        [MaxLength(50)]
        public string Model { get; set; }

        [Range(1900, 2100, ErrorMessage = "Geçerli bir model yılı giriniz.")]
        public int ModelYili { get; set; }

        [Required]
        [MaxLength(15)]
        public string Plaka { get; set; }

        [Range(0.01, 10000, ErrorMessage = "Günlük kira ücreti geçerli bir değer olmalıdır.")]
        public decimal GunlukKiraUcreti { get; set; }

        // Müşteri arayüzü için:
        public string Aciklama { get; set; }
        public bool KiradaMi { get; set; } = false; // Varsayılan olarak kirada değil.
    }
}