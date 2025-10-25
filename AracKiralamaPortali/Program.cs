using AracKiralamaPortali.Data;
using Microsoft.EntityFrameworkCore;
using AracKiralamaPortali.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container

// 1. Veritabaný Baðlamýný (DbContext) Sisteme Kaydetme:
builder.Services.AddDbContext<AracKiralamaDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// 2. Repository Servisini Sisteme Kaydetme:
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));


// COOKIE AUTHENTICATION HÝZMETÝ TANIMLAMA
// 1. Kimlik Doðrulama hizmetini ekle (Authentication)
builder.Services.AddAuthentication("AdminAuth") 
    .AddCookie("AdminAuth", options => 
    {
        // Kullanýcý yetkisi yoksa, otomatik olarak bu sayfaya yönlendir.
        options.LoginPath = "/Admin/Login";
        // Yetkisiz eriþim denemesi olduðunda gösterilecek sayfa (opsiyonel)
        options.AccessDeniedPath = "/Admin/AccessDenied";
        // Cookie'nin ne kadar süre geçerli olacaðýný ayarla (30 dakika)
        options.ExpireTimeSpan = TimeSpan.FromMinutes(30);
        // Kullanýcý "Beni Hatýrla" seçeneðini iþaretlerse, Cookie'nin süresini uzat.
        options.SlidingExpiration = true;
    });


builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
