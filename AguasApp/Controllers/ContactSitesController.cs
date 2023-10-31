using Microsoft.AspNetCore.Mvc;

namespace AguasApp.Controllers
{
    public class ContactSitesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }
    }
}
