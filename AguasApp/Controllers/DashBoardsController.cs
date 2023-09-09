using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AguasApp.Controllers
{
    public class DashBoardsController : Controller
    {
        // GET: DashBoardsController
        public ActionResult Index()
        {
            return View();
        }

        
    }
}
