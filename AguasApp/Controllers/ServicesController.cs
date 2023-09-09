using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AguasApp.Data;
using AguasApp.Data.Entities;
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace AguasApp.Controllers
{
    public class ServicesController : Controller
    {
        private readonly IServiceRepository _serviceRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public ServicesController( IServiceRepository serviceRepository, IWebHostEnvironment webHostEnvironment)
        {
            _serviceRepository = serviceRepository;
            _webHostEnvironment = webHostEnvironment;
        }

        // GET: Mostrar todos Services
        public IActionResult Index()
        {
            var service = _serviceRepository.GetAll().OrderBy(p => p.Name);

            return View(service);
        }

        // GET: Mostrar o DETALHE DE CADA services/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var service = await _serviceRepository.GetByIdAsync(id.Value);

            if (service == null)
            {
                return NotFound();
            }

            return View(service);
        }

        // GET: Mostar a view do CREATE services/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ADICIONAR services/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Service service)
        {
            if (ModelState.IsValid)
            {
                //-----save image to wwwroot/image-->"CREATE"----
                string wwwRootPath = _webHostEnvironment.WebRootPath;
                string fileName = Path.GetFileNameWithoutExtension(service.ImageFile.FileName);
                string extension = Path.GetExtension(service.ImageFile.FileName);
                service.Image = fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                string path = Path.Combine(wwwRootPath + "/images/", fileName);
                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    await service.ImageFile.CopyToAsync(fileStream);
                }
                //-----End save image to wwwroot/image-->"CREATE"----
                await _serviceRepository.CreateAsync(service); // Adicionar e Guardar(O guardar fez-se no Geneneric) 
                return RedirectToAction(nameof(Index));// Retornar na views index
            }
            return View(service);
        }

        // GET:MOSTRAR CADA PRODUTO POR EDITAR(services/Edit/5)
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var service = await _serviceRepository.GetByIdAsync(id.Value);

            if (service == null)
            {
                return NotFound();
            }
            return View(service);
        }

        // POST: services/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Service service)
        {
            if (id != service.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                //-----save image to wwwroot/image-->"EDIT"----
                string wwwRootPath = _webHostEnvironment.WebRootPath;
                string fileName = Path.GetFileNameWithoutExtension(service.ImageFile.FileName);
                string extension = Path.GetExtension(service.ImageFile.FileName);
                service.Image = fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                string path = Path.Combine(wwwRootPath + "/images/", fileName);
                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    await service.ImageFile.CopyToAsync(fileStream);
                }
                //-----End save image to wwwroot/image-->"EDIT"----

                try
                {
                    await _serviceRepository.UpdateAsync(service);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await _serviceRepository.ExistAsync(service.Id))
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
            return View(service);
        }

        // GET: MOSTRAR CADA PRODUTO POR APAGAR services/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var service = await _serviceRepository.GetByIdAsync(id.Value);
            if (service == null)
            {
                return NotFound();
            }

            return View(service);
        }

        // POST: APAGAR PRODUTO services/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var service = await _serviceRepository.GetByIdAsync(id);

            //------ Delete image from wwwroot/image-->"DELETE"----
            var imagePath = Path.Combine(_webHostEnvironment.WebRootPath, "image", service.Image);
            if (System.IO.File.Exists(imagePath))
                System.IO.File.Delete(imagePath);
            //------ Delete image from wwwroot/image-->"DELETE"----

            await _serviceRepository.DeleteAsync(service);
            return RedirectToAction(nameof(Index));
        }
    }
}
