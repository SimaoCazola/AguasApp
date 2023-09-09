using AguasApp.Data;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace AguasApp.Controllers
{
    public class ServiceSitesController : Controller
    {
        private readonly IServiceRepository _serviceRepository;

        public ServiceSitesController(IServiceRepository serviceRepository)
        {
            _serviceRepository = serviceRepository;
        }

        public IActionResult Index()
        {
            var service = _serviceRepository.GetAll().OrderBy(x => x.Name).ToList();
            return View(service);
        }
    }
}
