using Microsoft.AspNetCore.Mvc;

namespace AguasApp.Controllers
{
    public class AboutSitesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
