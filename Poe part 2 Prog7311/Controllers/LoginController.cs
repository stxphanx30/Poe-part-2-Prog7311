using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Poe_part_2_Prog7311.Models;

namespace Poe_part_2_Prog7311.Controllers
{
    public class LoginController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;
        public LoginController(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(string email, string password)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user != null)
            {
                var result = await _signInManager.PasswordSignInAsync(user, password, false, false);
                if (result.Succeeded)
                {
                    var roles = await _userManager.GetRolesAsync(user);
                    if (roles.Contains("Farmer"))
                        return RedirectToAction("FarmerHome", "Farmer");

                    if (roles.Contains("Employee"))
                        return RedirectToAction("EmployeeHome", "Employee");
                }
            }

            ViewBag.Error = "Invalid credentials.";
            return RedirectToAction("LoginFailed", "Login"); ;
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
        [HttpGet]
        public IActionResult AccessDenied()
        {
            return View();
        }
        public IActionResult    LoginFailed()
        {
            return View();
        }
    }
}
