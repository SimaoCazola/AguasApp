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
    public class WaterMetersController : Controller
    {
        private readonly DataContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public WaterMetersController(DataContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        // GET: WaterMeters
        public async Task<IActionResult> Index()
        {
            return View(await _context.WaterMeters.ToListAsync());
        }

        // GET: WaterMeters/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var waterMeter = await _context.WaterMeters
                .FirstOrDefaultAsync(m => m.Id == id);
            if (waterMeter == null)
            {
                return NotFound();
            }

            return View(waterMeter);
        }

        // GET: WaterMeters/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: WaterMeters/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(WaterMeter waterMeter)
        {
            if (ModelState.IsValid)
            {
                //-----save image to wwwroot/image-->"CREATE"----
                string wwwRootPath = _webHostEnvironment.WebRootPath;
                string fileName = Path.GetFileNameWithoutExtension(waterMeter.ImageFile.FileName);
                string extension = Path.GetExtension(waterMeter.ImageFile.FileName);
                waterMeter.Image = fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                string path = Path.Combine(wwwRootPath + "/images/", fileName);
                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    await waterMeter.ImageFile.CopyToAsync(fileStream);
                }
                //-----End save image to wwwroot/image-->"CREATE"----
                _context.Add(waterMeter);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(waterMeter);
        }

        // GET: WaterMeters/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var waterMeter = await _context.WaterMeters.FindAsync(id);
            if (waterMeter == null)
            {
                return NotFound();
            }
            return View(waterMeter);
        }

        // POST: WaterMeters/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, WaterMeter waterMeter)
        {
            if (id != waterMeter.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                //-----save image to wwwroot/image-->"CREATE"----
                string wwwRootPath = _webHostEnvironment.WebRootPath;
                string fileName = Path.GetFileNameWithoutExtension(waterMeter.ImageFile.FileName);
                string extension = Path.GetExtension(waterMeter.ImageFile.FileName);
                waterMeter.Image = fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                string path = Path.Combine(wwwRootPath + "/images/", fileName);
                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    await waterMeter.ImageFile.CopyToAsync(fileStream);
                }
                //-----End save image to wwwroot/image-->"CREATE"----
                try
                {
                    _context.Update(waterMeter);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WaterMeterExists(waterMeter.Id))
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
            return View(waterMeter);
        }

        // GET: WaterMeters/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var waterMeter = await _context.WaterMeters
                .FirstOrDefaultAsync(m => m.Id == id);
            if (waterMeter == null)
            {
                return NotFound();
            }

            return View(waterMeter);
        }

        // POST: WaterMeters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var waterMeter = await _context.WaterMeters.FindAsync(id);
            //------ Delete image from wwwroot/image-->"DELETE"----
            var imagePath = Path.Combine(_webHostEnvironment.WebRootPath, "images", waterMeter.Image);
            if (System.IO.File.Exists(imagePath))
                System.IO.File.Delete(imagePath);
            //------ Delete image from wwwroot/image-->"DELETE"----

            _context.WaterMeters.Remove(waterMeter);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WaterMeterExists(int id)
        {
            return _context.WaterMeters.Any(e => e.Id == id);
        }
    }
}
