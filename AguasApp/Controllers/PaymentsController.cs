using AguasApp.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

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
