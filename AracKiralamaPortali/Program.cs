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

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
