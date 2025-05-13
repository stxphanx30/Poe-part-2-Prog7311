using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Poe_part_2_Prog7311.Controllers
{
    [Authorize(Roles = "Employee")]
    public class EmployeeController : Controller
    {
        public IActionResult AddFarmer()
        {
            return View();
        }
        public IActionResult EditFarmer()
        {
            return View();
        }
        public IActionResult EmployeeHome()
        {
            return View();
        }
        public IActionResult Farmer()
        {
            return View();
        }
    }
}
