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
    options.LoginPath = "/Login/Login";                
    options.AccessDeniedPath = "/Login/AccessDenied";   
});

// Connect to the sql database
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Seed Roles, Users & Products
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    // step 1 seed roles and users
    await DbInitializer.SeedRolesAndUsersAsync(services);

    // step 2 : Seed product database
    await DbInitializer.SeedProductsAsync(services);
}

// Configure http pipeline
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