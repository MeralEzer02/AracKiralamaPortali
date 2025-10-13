using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace AracKiralamaPortali.Data
{
    public class AracKiralamaDbContextFactory : IDesignTimeDbContextFactory<AracKiralamaDbContext>
    {
        public AracKiralamaDbContext CreateDbContext(string[] args)
        {
            // 1. Ayar dosyasını (appsettings.json) bulup yükle:
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            // 2. Bağlantı dizesini oku:
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            // 3. DbContextOptions'ı oluştur:
            var builder = new DbContextOptionsBuilder<AracKiralamaDbContext>();
            builder.UseSqlServer(connectionString);

            // 4. DbContext'i oluştur ve döndür:
            return new AracKiralamaDbContext(builder.Options);
        }
    }
}