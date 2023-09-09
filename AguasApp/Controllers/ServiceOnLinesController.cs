using Microsoft.AspNetCore.Mvc;

namespace AguasApp.Controllers
{
    public class ServiceOnLinesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
