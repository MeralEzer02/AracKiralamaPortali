using AracKiralamaPortali.Data;
using Microsoft.EntityFrameworkCore;
using AracKiralamaPortali.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container

// 1. Veritabaný Baðlamýný (DbContext) Sisteme Kaydetme:
builder.Services.AddDbContext<CarRentalDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// 2. Repository Servisini Sisteme Kaydetme:
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));


// COOKIE AUTHENTICATION HÝZMETÝ TANIMLAMA
// 1. Kimlik Doðrulama hizmetini ekle (Authentication)
builder.Services.AddAuthentication("AdminAuth")
    .AddCookie("AdminAuth", options =>
    {
        options.LoginPath = "/Admin/Login";
        options.AccessDeniedPath = "/Admin/AccessDenied";
        options.ExpireTimeSpan = TimeSpan.FromMinutes(30);
        options.SlidingExpiration = true;
    });

// 3. MVC Hizmetini Tanýmlama (Þimdi burada AddMvc dahil, genellikle yeterli)
builder.Services.AddControllersWithViews();

// 4. (EKLENEN) Runtime tarafýnda View'lara veri taþýma için gereklidir.
builder.Services.AddHttpContextAccessor();


var app = builder.Build();

// ...
app.UseHttpsRedirection();
app.UseStaticFiles(); // Bu, CSS/JS dosyalarýnýn çalýþmasý için gereklidir.

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

// --------------------------------------------------------------------------------
// BURASI KRÝTÝK NOKTA: SADECE STANDART VE ÖZNÝTELÝK TABANLI ROUTING KALSIN
// --------------------------------------------------------------------------------

// 1. Öznitelik Tabanlý Yönlendirmeyi Tanýt (AdminController için hayati)
// app.MapControllers();
app.MapControllerRoute(
    name: "admin",
    pattern: "Admin/{action=Index}/{id?}",
    defaults: new { controller = "Admin" });

// 2. Geleneksel Yönlendirme (Varsayýlan Home Controller için)
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// app.MapStaticAssets(); ve .WithStaticAssets(); SÝLÝNDÝ!


app.Run();