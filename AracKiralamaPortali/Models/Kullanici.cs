using System.ComponentModel.DataAnnotations;

namespace AracKiralamaPortali.Models
{
    public class Kullanici
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Email { get; set; } // Kullanıcı adı olarak kullanacağız.

        [Required]
        public string SifreHash { get; set; }

        [Required]
        public string Rol { get; set; }

        public DateTime KayitTarihi { get; set; } = DateTime.Now;
    }
}