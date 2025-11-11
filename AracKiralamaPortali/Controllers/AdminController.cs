using Microsoft.AspNetCore.Mvc;
using AracKiralamaPortali.ViewModels; // Bu namespace'i değiştireceğiz
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;
using AracKiralamaPortali.Repositories;
using AracKiralamaPortali.Models;
using System.Collections.Generic;
using System.Linq;

namespace CarRentalPortal.Controllers
{
    public class AdminController : Controller
    {
        // -------------------------------------------------------------------
        // 1. REPOSITORY ALANINI TANIMLAMA (FIELD):
        // -------------------------------------------------------------------
        private readonly IGenericRepository<Vehicle> _vehicleRepository;

        // -------------------------------------------------------------------
        // 2. KURUCU METOT (CONSTRUCTOR) - DEPENDENCY INJECTION (DI) İÇİN:
        // -------------------------------------------------------------------
        public AdminController(IGenericRepository<Vehicle> vehicleRepository)
        {
            _vehicleRepository = vehicleRepository;
        }
        public IActionResult Index()
        {
            return View();
        }

        // -------------------------------------------------------------------
        // ADIM 10.2: ARAÇ LİSTELEME ACTION'I (READ) - Vehicles olarak adlandırıldı.
        // -------------------------------------------------------------------
        public async Task<IActionResult> Vehicles()
        {
            // 1. Entity'leri Repository'den Çekme
            var vehicleEntities = await _vehicleRepository.GetAllAsync();

            // 2. Mapping (Eşleme) İşlemi: Entity -> ViewModel
            var vehicleViewModels = vehicleEntities.Select(vehicle => new VehicleListViewModel 
            {
                Id = vehicle.Id,
                Marka = vehicle.Marka,
                Model = vehicle.Model,
                ModelYili = vehicle.ModelYili,
                Plaka = vehicle.Plaka,
                GunlukKiraUcreti = vehicle.GunlukKiraUcreti,
                KiradaMi = vehicle.KiradaMi,
            }).ToList();

            // 3. View'a Gönderme
            return View(vehicleViewModels);
        }
    }
}