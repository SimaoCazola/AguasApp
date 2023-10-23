using Microsoft.AspNetCore.Mvc;

namespace AguasApp.Controllers
{
    public class PaymentsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult OrderNow()
        {
            return View();
        }
        


    }
}
