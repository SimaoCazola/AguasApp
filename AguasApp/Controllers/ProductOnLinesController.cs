using Microsoft.AspNetCore.Mvc;

namespace AguasApp.Controllers
{
    public class ProductOnLinesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
