using Microsoft.AspNetCore.Identity;
using Poe_part_2_Prog7311.Data;
using Poe_part_2_Prog7311.Models;
using System;

public static class DbInitializer
{
    public static async Task SeedRolesAndUsersAsync(IServiceProvider serviceProvider)
    {
        var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
        var userManager = serviceProvider.GetRequiredService<UserManager<AppUser>>();

      
        string[] roles = { "Farmer", "Employee" };
        foreach (var role in roles)
        {
            if (!await roleManager.RoleExistsAsync(role))
                await roleManager.CreateAsync(new IdentityRole(role));
        }

        // 🔹 Farmer
        string farmerEmail = "farmer1@agrienergy.com";
        string farmerPassword = "Farmer@123";

        var farmerUser = await userManager.FindByEmailAsync(farmerEmail);
        if (farmerUser == null)
        {
            var newUser = new AppUser
            {
                UserName = farmerEmail,
                Email = farmerEmail,
                FullName = "John Green",
                IDNumber = "FARM123456",
                Address = "123 Greenfield Farm, Cape Town",
                PhoneNumber = "0761234567",
                EmailConfirmed = true,
                PassportPhotoPath = "/img/DefaultUser.png"
            };

            var result = await userManager.CreateAsync(newUser, farmerPassword);
            if (result.Succeeded)
                await userManager.AddToRoleAsync(newUser, "Farmer");
        }
        else
        {
            bool updated = false;

            if (string.IsNullOrWhiteSpace(farmerUser.FullName))
            {
                farmerUser.FullName = "John Green";
                updated = true;
            }
            if (string.IsNullOrWhiteSpace(farmerUser.IDNumber))
            {
                farmerUser.IDNumber = "FARM123456";
                updated = true;
            }
            if (string.IsNullOrWhiteSpace(farmerUser.Address))
            {
                farmerUser.Address = "123 Greenfield Farm, Cape Town";
                updated = true;
            }
            if (string.IsNullOrWhiteSpace(farmerUser.PhoneNumber))
            {
                farmerUser.PhoneNumber = "0761234567";
                updated = true;
            }
            if (string.IsNullOrWhiteSpace(farmerUser.PassportPhotoPath))
            {
                farmerUser.PassportPhotoPath = "/img/DefaultUser.png";
                updated = true;
            }

            if (updated)
                await userManager.UpdateAsync(farmerUser);

            if (!await userManager.IsInRoleAsync(farmerUser, "Farmer"))
                await userManager.AddToRoleAsync(farmerUser, "Farmer");
        }

        // 🔹 Employee
        string employeeEmail = "employee1@agrienergy.com";
        string employeePassword = "Employee@123";

        var employeeUser = await userManager.FindByEmailAsync(employeeEmail);
        if (employeeUser == null)
        {
            var newUser = new AppUser
            {
                UserName = employeeEmail,
                Email = employeeEmail,
                FullName = "Emma Blue",
                IDNumber = "EMP789456",
                Address = "456 Admin Rd, Johannesburg",
                PhoneNumber = "0823456789",
                EmailConfirmed = true,
                PassportPhotoPath = "/img/DefaultUser.png"
            };

            var result = await userManager.CreateAsync(newUser, employeePassword);
            if (result.Succeeded)
                await userManager.AddToRoleAsync(newUser, "Employee");
        }
        else
        {
            bool updated = false;

            if (string.IsNullOrWhiteSpace(employeeUser.FullName))
            {
                employeeUser.FullName = "Emma Blue";
                updated = true;
            }
            if (string.IsNullOrWhiteSpace(employeeUser.IDNumber))
            {
                employeeUser.IDNumber = "EMP789456";
                updated = true;
            }
            if (string.IsNullOrWhiteSpace(employeeUser.Address))
            {
                employeeUser.Address = "456 Admin Rd, Johannesburg";
                updated = true;
            }
            if (string.IsNullOrWhiteSpace(employeeUser.PhoneNumber))
            {
                employeeUser.PhoneNumber = "0823456789";
                updated = true;
            }
            if (string.IsNullOrWhiteSpace(employeeUser.PassportPhotoPath))
            {
                employeeUser.PassportPhotoPath = "/img/DefaultUser.png";
                updated = true;
            }

            if (updated)
                await userManager.UpdateAsync(employeeUser);

            if (!await userManager.IsInRoleAsync(employeeUser, "Employee"))
                await userManager.AddToRoleAsync(employeeUser, "Employee");
        }
    }
    public static async Task SeedProductsAsync(IServiceProvider serviceProvider)
    {
        var context = serviceProvider.GetRequiredService<ApplicationDbContext>();
        var userManager = serviceProvider.GetRequiredService<UserManager<AppUser>>();

        await context.Database.EnsureCreatedAsync();

        // Check si produits déjà ajoutés
        if (context.Products.Any()) return;

        // On récupère le fermier existant
        var farmer = await userManager.FindByEmailAsync("farmer1@agrienergy.com");

        if (farmer == null)
        {
            Console.WriteLine("Farmer not found. Cannot seed products.");
            return;
        }

        // On ajoute les produits
        var products = new List<Product>
    {
        new Product
{
    Name = "Fresh Apples",
    Category = "Fruits",
    ProductionDate = DateTime.Today.AddDays(-3),
    ImagePath = "/img/apples.jpg",
    FarmerId = farmer.Id
},
new Product
{
    Name = "Raw Cow Milk",
    Category = "Dairy",
    ProductionDate = DateTime.Today.AddDays(-1),
    ImagePath = "/img/milk.jpg",
    FarmerId = farmer.Id
},
new Product
{
    Name = "Free-range Chicken",
    Category = "Livestock",
    ProductionDate = DateTime.Today.AddDays(-7),
    ImagePath = "/img/chicken.jpg",
    FarmerId = farmer.Id
}
    };

        context.Products.AddRange(products);
        await context.SaveChangesAsync();
    }
}