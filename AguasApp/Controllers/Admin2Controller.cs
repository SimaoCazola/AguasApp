using Microsoft.AspNetCore.Mvc;

namespace AguasApp.Controllers
{
    public class Admin2Controller : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
