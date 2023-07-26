using Microsoft.AspNetCore.Mvc;

namespace AguasApp.Controllers
{
    public class ServiceSitesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
