using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Poe_part_2_Prog7311.Data;
using Poe_part_2_Prog7311.Models;

using System;

namespace Poe_part_2_Prog7311.Controllers
{
    [Authorize(Roles = "Employee")]
    public class EmployeeController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<AppUser> _userManager;
        private readonly IWebHostEnvironment _env;
        public EmployeeController(ApplicationDbContext context, UserManager<AppUser> userManager, IWebHostEnvironment env)
        {
            _context = context;
            _userManager = userManager;
            _env = env;
        }

        [HttpGet]
        public async Task<IActionResult> EditFarmer(string id)
        {
            var farmer = await _userManager.FindByIdAsync(id);
            if (farmer == null || !(await _userManager.IsInRoleAsync(farmer, "Farmer")))
                return NotFound();

            var model = new FarmerRegistrationViewModel
            {
                Id = farmer.Id,
                FullName = farmer.FullName,
                Email = farmer.Email,
                PhoneNumber = farmer.PhoneNumber,
                IDNumber = farmer.IDNumber,
                Address = farmer.Address
            };

            return View(model);
        }

        // POST: Edit Farmer
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditFarmer(FarmerRegistrationViewModel model, IFormFile? passportPhoto)
        {
            if (!ModelState.IsValid)
                return View(model);

            var farmer = await _userManager.FindByIdAsync(model.Id);
            if (farmer == null)
                return NotFound();

            farmer.FullName = model.FullName;
            farmer.Email = model.Email;
            farmer.UserName = model.Email;
            farmer.PhoneNumber = model.PhoneNumber;
            farmer.IDNumber = model.IDNumber;
            farmer.Address = model.Address;

            if (passportPhoto != null && passportPhoto.Length > 0)
            {
                var fileName = Guid.NewGuid().ToString() + Path.GetExtension(passportPhoto.FileName);
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img", fileName);
                using var stream = new FileStream(path, FileMode.Create);
                await passportPhoto.CopyToAsync(stream);
                farmer.PassportPhotoPath = "/img/" + fileName;
            }

            var result = await _userManager.UpdateAsync(farmer);
            if (result.Succeeded)
                return RedirectToAction("Farmer");

            foreach (var error in result.Errors)
                ModelState.AddModelError("", error.Description);

            return View(model);
        }

        // GET: Delete Farmer
        [HttpGet]
        public async Task<IActionResult> DeleteFarmer(string id)
        {
            var farmer = await _userManager.FindByIdAsync(id);
            if (farmer == null)
                return NotFound();

            return View(farmer);
        }

        // POST: Confirm Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteFarmerConfirmed(string id)
        {
            var farmer = await _userManager.FindByIdAsync(id);
            if (farmer == null)
                return NotFound();

            await _userManager.DeleteAsync(farmer);
            return RedirectToAction("Farmer");
        }
        public IActionResult EmployeeHome()
        {
            return View();
        }
        public async Task<IActionResult> ViewFarmerProduct(string searchString, string category, DateTime? productionDate)
        {
            var query = _context.Products.Include(p => p.Farmer).AsQueryable();


            if (!string.IsNullOrEmpty(searchString))
            {
                query = query.Where(p => p.Name.Contains(searchString));
            }

            if (!string.IsNullOrEmpty(category))
            {
                query = query.Where(p => p.Category == category);
            }

            if (productionDate.HasValue)
            {
                query = query.Where(p => p.ProductionDate.Date == productionDate.Value.Date);
            }

            var products = await query.ToListAsync();
            return View(products);
        }
        // GET: Display the Add Farmer form
        [HttpGet]
        public IActionResult AddFarmer()
        {
            return View();
        }

        // POST: Handle form submission
        [HttpPost]
        public async Task<IActionResult> AddFarmer(FarmerRegistrationViewModel model, IFormFile PassportPhoto)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            // picture management
            string photoPath = null;

            if (PassportPhoto != null && PassportPhoto.Length > 0)
            {
                string uploadsFolder = Path.Combine(_env.WebRootPath, "img");

                
                Directory.CreateDirectory(uploadsFolder);

                string fileName = Guid.NewGuid().ToString() + Path.GetExtension(PassportPhoto.FileName);
                string filePath = Path.Combine(uploadsFolder, fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await PassportPhoto.CopyToAsync(stream);
                }

                photoPath = "/img/" + fileName;
            }

            var farmer = new AppUser
            {
                UserName = model.Email,
                Email = model.Email,
                FullName = model.FullName,
                IDNumber = model.IDNumber,
                Address = model.Address,
                PhoneNumber = model.PhoneNumber,
                PassportPhotoPath = photoPath
            };

            var result = await _userManager.CreateAsync(farmer, model.Password);

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(farmer, "Farmer");
                return RedirectToAction("Farmer"); 
            }

            
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }

            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> Farmer()
        {
            var allUsers = await _userManager.Users.ToListAsync();
            var farmers = new List<AppUser>();

foreach (var user in allUsers)
            {
                if (await _userManager.IsInRoleAsync(user, "Farmer"))
                {
                    farmers.Add(user);
                }
            }

            return View(farmers);
        }
    }
}

