using AguasApp.Data;
using AguasApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace AguasApp.Controllers
{
    public class ProductSitesController : Controller
    {
        private readonly IProductRepository _productRepository;

        public ProductSitesController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
           
        }
        public IActionResult Index()
        {
            var products = _productRepository.GetAll().OrderBy(x => x.Name).ToList(); 
            return View(products);
        }

        //Get Product Details
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _productRepository.GetByIdAsync(id.Value);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }
    }
}
