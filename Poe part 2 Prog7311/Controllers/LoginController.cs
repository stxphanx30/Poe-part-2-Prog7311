using Microsoft.AspNetCore.Mvc;

namespace Poe_part_2_Prog7311.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
    }
}
