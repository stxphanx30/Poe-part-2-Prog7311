using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Poe_part_2_Prog7311.Data;
using Poe_part_2_Prog7311.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllersWithViews();

// Add Identity with custom AppUser
builder.Services.AddIdentity<AppUser, IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();

// Configurer les chemins de redirection
builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Login/Login";                 // si non connect�
    options.AccessDeniedPath = "/Login/AccessDenied";   // si connect� mais pas autoris�
});

// Connecter � la base de donn�es SQL Server
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Seed Roles, Users & Products
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    // �tape 1 : Seed des r�les et des utilisateurs
    await DbInitializer.SeedRolesAndUsersAsync(services);

    // �tape 2 : Seed des produits pour le fermier d�j� cr��
    await DbInitializer.SeedProductsAsync(services);
}

// Configure le pipeline HTTP
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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();