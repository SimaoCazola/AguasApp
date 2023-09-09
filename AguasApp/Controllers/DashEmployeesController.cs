using Microsoft.AspNetCore.Mvc;

namespace AguasApp.Controllers
{
    public class DashEmployeesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
