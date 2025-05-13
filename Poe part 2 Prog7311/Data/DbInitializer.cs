using Microsoft.AspNetCore.Identity;
using Poe_part_2_Prog7311.Models;

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

        // Créer un utilisateur Farmer
        string farmerEmail = "farmer1@agrienergy.com";
        string farmerPassword = "Farmer@123";

        var farmerUser = await userManager.FindByEmailAsync(farmerEmail);
        if (farmerUser == null)
        {
            var user = new AppUser
            {
                UserName = farmerEmail,
                Email = farmerEmail,
                EmailConfirmed = true
            };

            var result = await userManager.CreateAsync(user, farmerPassword);
            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(user, "Farmer");
            }
        }

        // Créer un utilisateur Employee
        string employeeEmail = "employee1@agrienergy.com";
        string employeePassword = "Employee@123";

        var employeeUser = await userManager.FindByEmailAsync(employeeEmail);
        if (employeeUser == null)
        {
            var user = new AppUser
            {
                UserName = employeeEmail,
                Email = employeeEmail,
                EmailConfirmed = true
            };

            var result = await userManager.CreateAsync(user, employeePassword);
            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(user, "Employee");
            }
        }
    }
}