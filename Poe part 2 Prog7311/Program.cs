using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Poe_part_2_Prog7311.Data;
using Poe_part_2_Prog7311.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Add Identity (User + Role) with your custom AppUser
builder.Services.AddIdentity<AppUser, IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();

// Configurer les chemins de redirection pour Login & Accès refusé
builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Login/Login";             // si non connecté
    options.AccessDeniedPath = "/Login/AccessDenied"; // si connecté mais rôle incorrect
});

// Connect to your SQL Server database
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Seed roles and default users (Farmer & Employee)
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    await DbInitializer.SeedRolesAndUsersAsync(services);
}

// Configure the HTTP request pipeline.
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