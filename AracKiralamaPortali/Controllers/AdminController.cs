using Microsoft.AspNetCore.Mvc;
using AracKiralamaPortali.ViewModels;

namespace AracKiralamaPortali.Controllers
{
    [Route("Admin")]
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        // -------------------------------------------------------------------
        // ADMİN GİRİŞ (LOGIN) İŞLEMLERİ
        // -------------------------------------------------------------------

        [HttpGet("Login")]
        public IActionResult Login()
        {
            return View(new AdminLoginViewModel());
        }

        [HttpPost("Login")]
        [ValidateAntiForgeryToken]
        public IActionResult Login(AdminLoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (model.Email == "admin@test.com" && model.Şifre == "123456")
            {
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "E-posta veya şifre hatalı.");
            return View(model);
        }
    }
}