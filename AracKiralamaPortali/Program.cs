using CarRentalPortal.Data;
using Microsoft.EntityFrameworkCore;
using CarRentalPortal.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<CarRentalDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

// COOKIE AUTHENTICATION HÝZMETÝ TANIMLAMA
// Authentication
builder.Services.AddAuthentication("AdminAuth")
    .AddCookie("AdminAuth", options =>
    {
        options.LoginPath = "/Admin/Login";
        options.AccessDeniedPath = "/Admin/AccessDenied";
        options.ExpireTimeSpan = TimeSpan.FromMinutes(30);
        options.SlidingExpiration = true;
    });

// 3. MVC Hizmetini Tanýmlama
builder.Services.AddControllersWithViews();

builder.Services.AddHttpContextAccessor();


var app = builder.Build();


if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


app.Run();