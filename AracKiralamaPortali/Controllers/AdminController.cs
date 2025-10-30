using Microsoft.AspNetCore.Mvc;
using AracKiralamaPortali.ViewModels;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;
using AracKiralamaPortali.Repositories;
using AracKiralamaPortali.Models; 
using System.Collections.Generic;
using System.Linq;

namespace AracKiralamaPortali.Controllers
{
    [Route("Admin")]
    [Authorize(AuthenticationSchemes = "AdminAuth", Roles = "Admin")]
    public class AdminController : Controller
    {
        // -------------------------------------------------------------------
        // 1. REPOSITORY ALANINI TANIMLAMA (Private Field):
        // -------------------------------------------------------------------
        private readonly IGenericRepository<Arac> _aracRepository;

        // -------------------------------------------------------------------
        // 2. KURUCU METOT (CONSTRUCTOR) - DEPENDENCY INJECTION (DI) İÇİN:
        // -------------------------------------------------------------------
        public AdminController(IGenericRepository<Arac> aracRepository)
        {
            _aracRepository = aracRepository; 
        }

        public IActionResult Index()
        {
            // ...
            return View();
        }

        // -------------------------------------------------------------------
        // ADIM 10.2: ARAÇ LİSTELEME ACTION'I (READ) - BU KISIM YENİ EKLENECEK
        // -------------------------------------------------------------------

        [HttpGet("Araclar")]
        public async Task<IActionResult> Araclar()
        {
            var aracEntities = await _aracRepository.GetAllAsync();

            var aracViewModels = aracEntities.Select(arac => new AracListViewModel
            {
                Id = arac.Id,
                Marka = arac.Marka,
                Model = arac.Model,
                ModelYili = arac.ModelYili,
                Plaka = arac.Plaka,
                GunlukKiraUcreti = arac.GunlukKiraUcreti,
                KiradaMi = arac.KiradaMi,
            }).ToList();

            return View(aracViewModels);
        }
    }
}