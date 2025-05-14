using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Poe_part_2_Prog7311.Data;
using Poe_part_2_Prog7311.Models;
using System;

namespace Poe_part_2_Prog7311.Controllers
{
    [Authorize(Roles = "Farmer")]
    public class FarmerController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<AppUser> _userManager;
        private readonly IWebHostEnvironment _env;
        public FarmerController(ApplicationDbContext context, UserManager<AppUser> userManager, IWebHostEnvironment env)
        {
            _context = context;
            _userManager = userManager;
            _env = env;
        }

        public IActionResult FarmerHome()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddProduct()
        {
            return View(new Product());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddProduct(Product product, IFormFile imageFile)
        {
            if (!ModelState.IsValid)
            {
                foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
                {
                    Console.WriteLine("MODEL ERROR: " + error.ErrorMessage);
                }
                return View(product);
            }

            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                ModelState.AddModelError("", "User not found.");
                return View(product);
            }

            product.FarmerId = user.Id;

            if (imageFile != null && imageFile.Length > 0)
            {
                string uploadsFolder = Path.Combine(_env.WebRootPath, "img");

                
                Directory.CreateDirectory(uploadsFolder);

                string fileName = Guid.NewGuid().ToString() + Path.GetExtension(imageFile.FileName);
                string filePath = Path.Combine(uploadsFolder, fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await imageFile.CopyToAsync(stream);
                }

                product.ImagePath = "/img/" + fileName;
            }

            _context.Products.Add(product);
            Console.WriteLine("Farmer ID: " + product.FarmerId); // debug

            await _context.SaveChangesAsync();

            return RedirectToAction("MyProducts");
        }

        [HttpGet]
        public async Task<IActionResult> EditProduct(int id)
        {
            var user = await _userManager.GetUserAsync(User);
            var product = await _context.Products
                .FirstOrDefaultAsync(p => p.Id == id && p.FarmerId == user.Id);

            if (product == null)
                return NotFound();

            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditProduct(int id, Product product, IFormFile imageFile)
        {
            var user = await _userManager.GetUserAsync(User);
            var existing = await _context.Products
                .FirstOrDefaultAsync(p => p.Id == id && p.FarmerId == user.Id);

            if (existing == null)
                return NotFound();

            if (ModelState.IsValid)
            {
                existing.Name = product.Name;
                existing.Category = product.Category;
                existing.ProductionDate = product.ProductionDate;

                if (imageFile != null && imageFile.Length > 0)
                {
                    var uploadsFolder = Path.Combine(_env.WebRootPath, "img");
                    Directory.CreateDirectory(uploadsFolder); 

                    var fileName = Guid.NewGuid().ToString() + Path.GetExtension(imageFile.FileName);
                    var filePath = Path.Combine(uploadsFolder, fileName);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await imageFile.CopyToAsync(stream);
                    }

                    existing.ImagePath = "/img/" + fileName;
                }

                await _context.SaveChangesAsync();
                return RedirectToAction("MyProducts");
            }

            return View(product);
        }

        public async Task<IActionResult> MyProducts()
        {
            var user = await _userManager.GetUserAsync(User);
            var products = await _context.Products
                .Where(p => p.FarmerId == user.Id)
                .ToListAsync();

            return View(products);
        }

        [HttpGet]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var user = await _userManager.GetUserAsync(User);
            var product = await _context.Products
                .FirstOrDefaultAsync(p => p.Id == id && p.FarmerId == user.Id);

            if (product == null)
                return NotFound();

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            return RedirectToAction("MyProducts");
        }

    }
}