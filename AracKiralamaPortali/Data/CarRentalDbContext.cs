using AracKiralamaPortali.Models;
using CarRentalPortal.Models;
using Microsoft.EntityFrameworkCore;

namespace CarRentalPortal.Data
{
    public class CarRentalDbContext : DbContext
    {
        public CarRentalDbContext(DbContextOptions<CarRentalDbContext> options)
            : base(options)
        {
        }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<User> Users { get; set; }
    }
}