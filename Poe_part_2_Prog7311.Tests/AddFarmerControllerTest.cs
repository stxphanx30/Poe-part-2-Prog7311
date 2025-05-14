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
using Moq;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Text;

namespace Poe_part_2_Prog7311.Tests
{
    public class AddFarmerControllerTest
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
        public async Task AddFarmer_WithValidModel_ReturnsRedirectAndSavesImage()
        {
           
            var context = GetDbContext();

            
            var tempRoot = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());
            var imgDir = Path.Combine(tempRoot, "img");
            Directory.CreateDirectory(imgDir);

           
            var mockEnv = new Mock<IWebHostEnvironment>();
            mockEnv.Setup(e => e.WebRootPath).Returns(tempRoot);

           
            var store = new Mock<IUserStore<AppUser>>();
            var userManager = new Mock<UserManager<AppUser>>(
                store.Object, null, null, null, null, null, null, null, null
            );
            userManager.Setup(x => x.CreateAsync(It.IsAny<AppUser>(), It.IsAny<string>()))
                       .ReturnsAsync(IdentityResult.Success);
            userManager.Setup(x => x.CreateAsync(It.IsAny<AppUser>(), It.IsAny<string>()))
           .Callback<AppUser, string>((u, pwd) =>
           {
               context.Users.Add(u); 
               context.SaveChanges(); 
           })
           .ReturnsAsync(IdentityResult.Success);
            userManager.Setup(x => x.AddToRoleAsync(It.IsAny<AppUser>(), "Farmer"))
                       .ReturnsAsync(IdentityResult.Success);

            
            var controller = new EmployeeController(context, userManager.Object, mockEnv.Object);

            
            var viewModel = new FarmerRegistrationViewModel
            {
                FullName = "Test Farmer",
                Email = "test@farm.com",
                Password = "Test123@",
                IDNumber = "F123456",
                Address = "123 Green Way",
                PhoneNumber = "0123456789"
            };

           
            var fileContent = "image test";
            var fileName = "photo.jpg";
            var stream = new MemoryStream(Encoding.UTF8.GetBytes(fileContent));
            var formFile = new FormFile(stream, 0, stream.Length, "PassportPhoto", fileName)
            {
                Headers = new HeaderDictionary(),
                ContentType = "image/jpeg"
            };

            // Act
            var result = await controller.AddFarmer(viewModel, formFile);

            // Assert
            var redirect = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Farmer", redirect.ActionName); 

            var user = await context.Users.FirstOrDefaultAsync(u => u.Email == viewModel.Email);
            Assert.NotNull(user);
            Assert.StartsWith("/img/", user.PassportPhotoPath); 

           
            Directory.Delete(tempRoot, recursive: true);
        }
    }
}