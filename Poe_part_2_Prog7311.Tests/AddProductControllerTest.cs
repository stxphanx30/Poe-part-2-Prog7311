using Xunit;
using Poe_part_2_Prog7311.Models;
using Poe_part_2_Prog7311.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using Poe_part_2_Prog7311.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Moq;
using System.IO;
using System.Text;
using System.Security.Claims;

namespace Poe_part_2_Prog7311.Tests
{
    public class AddProductControllerTest
    {
        private ApplicationDbContext GetDbContext()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .EnableSensitiveDataLogging()
                .Options;

            return new ApplicationDbContext(options);
        }

        [Fact]
        public async Task AddProduct_ValidInput_SavesProductAndRedirects()
        {
           
            var context = GetDbContext();

            
            var farmer = new AppUser
            {
                Id = "f1",
                Email = "farmer@test.com",
                FullName = "Jean Farmer",
                IDNumber = "FRM123",
                Address = "123 Farm Way",
                PhoneNumber = "0812345678",
                PassportPhotoPath = "/img/farmer.jpg"
            };
            context.Users.Add(farmer);
            await context.SaveChangesAsync();

            var mockUserManager = new Mock<UserManager<AppUser>>(
                new Mock<IUserStore<AppUser>>().Object,
                null, null, null, null, null, null, null, null
            );
            mockUserManager.Setup(x => x.GetUserAsync(It.IsAny<ClaimsPrincipal>()))
                           .ReturnsAsync(farmer);

            var tempRoot = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());
            var imgDir = Path.Combine(tempRoot, "img");
            Directory.CreateDirectory(imgDir);

            var mockEnv = new Mock<IWebHostEnvironment>();
            mockEnv.Setup(e => e.WebRootPath).Returns(tempRoot);

            var controller = new FarmerController(context, mockUserManager.Object, mockEnv.Object);

            var product = new Product
            {
                Name = "Carrot",
                Category = "Vegetables",
                ProductionDate = DateTime.Today
            };

            var content = "fake image";
            var fileName = "carrot.jpg";
            var stream = new MemoryStream(Encoding.UTF8.GetBytes(content));
            var formFile = new FormFile(stream, 0, stream.Length, "ImageFile", fileName)
            {
                Headers = new HeaderDictionary(),
                ContentType = "image/jpeg"
            };

            // Act
            var result = await controller.AddProduct(product, formFile);

            // Assert
            var redirect = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("MyProducts", redirect.ActionName); 

            var savedProduct = await context.Products.FirstOrDefaultAsync(p => p.Name == "Carrot");
            Assert.NotNull(savedProduct);
            Assert.Equal(farmer.Id, savedProduct.FarmerId);
            Assert.StartsWith("/img/", savedProduct.ImagePath);

            Directory.Delete(tempRoot, recursive: true); // cleaning the moq file
        }
       
    }

}
