using Microsoft.AspNetCore.Mvc;

namespace Poe_part_2_Prog7311.Controllers
{
    public class FarmerController : Controller
    {
        public IActionResult FarmerHome()
        {
            return View();
        }
        public IActionResult EditProduct()
        {
            return View();
        }
        public IActionResult AddProduct()
        {
            return View();
        }
        public IActionResult FarmerProduct()
        {
            return View();
        }
    }
}
