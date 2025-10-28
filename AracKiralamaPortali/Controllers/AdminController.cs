using Microsoft.AspNetCore.Mvc;
using AracKiralamaPortali.ViewModels;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks; // async/await için gerekli

namespace AracKiralamaPortali.Controllers
{  
    // Controller Seviyesi Yetkilendirme Kilidi: 
    // Bu Controller'daki tüm Action'lara erişim için AdminAuth şemasıyla oturum açmış kullanıcı gereklidir...
    [Route("Admin")]
    [Authorize(AuthenticationSchemes = "AdminAuth", Roles = "Admin")] // KİLİT BURADA!
    public class AdminController : Controller
    {
        // Yetkili kullanıcıların göreceği ana sayfa (Dashboard)
        // [Authorize] özniteliği sayesinde, buraya sadece yetkili kullanıcılar ulaşabilir.
        public IActionResult Index()
        {
            return View();
        }

        // -------------------------------------------------------------------
        // ADMİN GİRİŞ (LOGIN) İŞLEMLERİ - BU ACTION KİLİTLİ DEĞİL!
        // -------------------------------------------------------------------

        [HttpGet("Login")]
        [AllowAnonymous] // Uzman Notu: Bu Action'ın kilitli OLMAMASI gerektiğini belirtir (Anonim erişime izin ver).
        public IActionResult Login()
        {
            // Kullanıcı zaten giriş yapmışsa, dashboard'a yönlendir.
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Admin");
            }

            return View(new AdminLoginViewModel());
        }

        [HttpPost("Login")]
        [AllowAnonymous] // Giriş işlemi herkese açık olmalı.
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(AdminLoginViewModel model) // ASYNC yapısını kullandık
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            // 1. Şifre Kontrolü (DB ENTEGRASYONU ÖNCESİ GEÇİCİ KONTROL):
            if (model.Email != "admin@test.com" || model.Şifre != "123456") // Not: Şifre büyük S harfi ile başlamadığı için düzeltildi: 'Sifre'
            {
                ModelState.AddModelError("", "E-posta veya şifre hatalı.");
                return View(model);
            }

            // 2. Kimlik Beyanı (Claims) Oluşturma: Kullanıcının kimlik kartı
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, model.Email),
                new Claim(ClaimTypes.Role, "Admin"), // ROL BİLGİSİ
            };

            // 3. Kimliği Tanımlama: Claims'i kullanarak bir kimlik nesnesi oluştur.
            var claimsIdentity = new ClaimsIdentity(claims, "AdminAuth");

            // 4. Authentication Özelliklerini Ayarlama: Cookie ömrü ayarları
            var authProperties = new AuthenticationProperties
            {
                IsPersistent = model.BeniHatirla, // Beni Hatırla işaretliyse kalıcı yap.
                ExpiresUtc = model.BeniHatirla ? DateTimeOffset.UtcNow.AddDays(7) : (DateTimeOffset?)null // 7 günlük kalıcılık süresi (Beni Hatırla için)
            };

            // 5. Cookie Oluşturma ve Tarayıcıya Gönderme (ASYNCHRONOUS İŞLEM):
            await HttpContext.SignInAsync("AdminAuth", // Program.cs'teki şema adı
                new ClaimsPrincipal(claimsIdentity), authProperties);

            // Başarılı giriş: Kullanıcıyı Dashboard'a yönlendir.
            return RedirectToAction("Index", "Admin");
        }

        // Kullanıcının oturumunu sonlandırma (Çıkış Yapma)
        [HttpGet("Logout")]
        [Authorize(AuthenticationSchemes = "AdminAuth")]
        public async Task<IActionResult> Logout()
        {
            // Tarayıcıdaki Cookie'yi siler ve oturumu sonlandırır.
            await HttpContext.SignOutAsync("AdminAuth");

            // Kullanıcıyı login sayfasına yönlendir.
            return RedirectToAction("Login", "Admin");
        }
    }
}