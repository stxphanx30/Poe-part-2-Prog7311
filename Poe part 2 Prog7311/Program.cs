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
    options.LoginPath = "/Login/Login";                 // si non connecté
    options.AccessDeniedPath = "/Login/AccessDenied";   // si connecté mais pas autorisé
});

// Connecter à la base de données SQL Server
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Seed Roles, Users & Products
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    // Étape 1 : Seed des rôles et des utilisateurs
    await DbInitializer.SeedRolesAndUsersAsync(services);

    // Étape 2 : Seed des produits pour le fermier déjà créé
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