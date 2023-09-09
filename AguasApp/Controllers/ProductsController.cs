using AguasApp.Data;
using AguasApp.Data.Entities;
using AguasApp.Helpers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;


namespace InoProject.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductRepository _productRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IUserHelper _userHelper;

        public ProductsController(IProductRepository productRepository, IWebHostEnvironment webHostEnvironment, IUserHelper userHelper)
        {
            _productRepository = productRepository;
            _webHostEnvironment = webHostEnvironment;
            _userHelper = userHelper;
        }

        // GET: Books--> Nao precisa de POST porque so vai mostrar a lista
        public IActionResult Index()
        {
            var product = _productRepository.GetAll().OrderBy(p => p.Name);

            return View(product);
        }

        // GET: Books/Create --> Mostrar a pagina ou view do Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Product product)
        {
            if (ModelState.IsValid)
            {

                //-----save image to wwwroot/image-->"CREATE"----
                string wwwRootPath = _webHostEnvironment.WebRootPath;
                string fileName = Path.GetFileNameWithoutExtension(product.ImageFile.FileName);
                string extension = Path.GetExtension(product.ImageFile.FileName);
                product.Image = fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                string path = Path.Combine(wwwRootPath + "/images/", fileName);
                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    await product.ImageFile.CopyToAsync(fileStream);
                }
                //-----End save image to wwwroot/image-->"CREATE"----

                product.User = await _userHelper.GetUserByEmailAsync(this.User.Identity.Name);
                await _productRepository.CreateAsync(product);
                return RedirectToAction(nameof(Index));
            }
            return View(product);
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



        // GET: Books/Edit/5 ---> Aqui usamos GetByIdAsync, porque para mostrar apenas um item por editar
        public async Task<IActionResult> Edit(int? id)
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

        // POST: Books/Edit/5 --> Aqui vamos usar o Update porque ja estamos a atualizar 
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Product product)
        {
            if (id != product.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {

                //-----save image to wwwroot/image-->"EDIT"----
                string wwwRootPath = _webHostEnvironment.WebRootPath;
                string fileName = Path.GetFileNameWithoutExtension(product.ImageFile.FileName);
                string extension = Path.GetExtension(product.ImageFile.FileName);
                product.Image = fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                string path = Path.Combine(wwwRootPath + "/images/", fileName);
                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    await product.ImageFile.CopyToAsync(fileStream);
                }
                //-----End save image to wwwroot/image-->"EDIT"----


                try
                {
                    product.User = await _userHelper.GetUserByEmailAsync(this.User.Identity.Name);
                    await _productRepository.UpdateAsync(product);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await _productRepository.ExistAsync(product.Id)) // Aqui vamos usar o existe
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        // GET: Books/Delete/5 ---> Aqui vamos usar o GetByIdAsync, porque queremos mostrar que vamos apagar apenas um livro
        public async Task<IActionResult> Delete(int? id)
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

        // POST: Books/Delete/5 ---> Aqui é onde realmente vamos apagar o livro
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);

            //------ Delete image from wwwroot/image-->"DELETE"----
            var imagePath = Path.Combine(_webHostEnvironment.WebRootPath, "images", product.Image);
            if (System.IO.File.Exists(imagePath))
                System.IO.File.Delete(imagePath);
            //------ Delete image from wwwroot/image-->"DELETE"----


            await _productRepository.DeleteAsync(product);
            return RedirectToAction(nameof(Index));
        }

      

    }
}
