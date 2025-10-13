using Microsoft.EntityFrameworkCore;
using AracKiralamaPortali.Models;
// using System.Diagnostics.CodeAnalysis; // Gerekirse eklenir

namespace AracKiralamaPortali.Data
{
    public class AracKiralamaDbContext : DbContext
    {
        public AracKiralamaDbContext(DbContextOptions<AracKiralamaDbContext> options)
            : base(options)
        {
        }
        public DbSet<Arac> Araclar { get; set; } 
        public DbSet<Kullanici> Kullanicilar { get; set; } 
    }
}