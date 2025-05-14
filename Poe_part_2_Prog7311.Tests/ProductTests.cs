using Xunit;
using Poe_part_2_Prog7311.Models;
using Poe_part_2_Prog7311.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Poe_part_2_Prog7311.Tests 
{
    public class ProductTests
    {
        private ApplicationDbContext GetDbContext()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase("TestDb")
                .Options;

            return new ApplicationDbContext(options);
        }

        [Fact]
        public async Task CanAddProduct()
        {
            var context = GetDbContext();
            var farmer = new AppUser
            {
                Id = "f1",
                FullName = "Farmer",
                UserName = "farmer@test.com",
                Email = "farmer@test.com",
                IDNumber = "FARM123",
                Address = "123 Farm Street",
                PhoneNumber = "0123456789",
                PassportPhotoPath = "/img/farmer.jpg"
            };
            context.Users.Add(farmer);

            var product = new Product
            {
                Name = "Tomato",
                Category = "Vegetables",
                ProductionDate = DateTime.Today,
                ImagePath = "/img/tomato.jpg",
                FarmerId = farmer.Id
            };

            context.Products.Add(product);
            await context.SaveChangesAsync();

            var result = await context.Products.FirstOrDefaultAsync(p => p.Name == "Tomato");

            Assert.NotNull(result);
            Assert.Equal("Vegetables", result.Category);
        }
    }
}