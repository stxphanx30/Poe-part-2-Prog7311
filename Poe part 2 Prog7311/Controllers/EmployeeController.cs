using Microsoft.AspNetCore.Mvc;

namespace Poe_part_2_Prog7311.Controllers
{
    public class EmployeeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
