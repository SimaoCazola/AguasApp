using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AguasApp.Data;
using AguasApp.Data.Entities;
using AguasApp.Models;

namespace AguasApp.Controllers
{
    public class MeterReadingsController : Controller
    {
        private readonly DataContext _context;

        public MeterReadingsController(DataContext context)
        {
            _context = context;
        }

        // GET: MeterReadings
        public async Task<IActionResult> Index()
        {
            return View(await _context.MeterReadings.ToListAsync());
        }

        // GET: MeterReadings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var meterReading = await _context.MeterReadings
                .FirstOrDefaultAsync(m => m.Id == id);
            if (meterReading == null)
            {
                return NotFound();
            }

            return View(meterReading);
        }

        // GET: MeterReadings/Create
        public IActionResult Create()
        {
            var customerList = _context.Customers.ToList();
            var waterMeterList = _context.WaterMeters.ToList();
            var viewModel = new MeterReadingViewModel
            {
                //Object Area
                MeterReading = new MeterReading(), // Inicializa uma nova instância de Invoice
                Customer = new Customer(), // Inicializa uma nova instância de Customer
                WaterMeter = new WaterMeter(),

                //List Area
                WaterMeters = waterMeterList,
                Customers = customerList // Obtém a lista de clientes
            };

            return View(viewModel);
        }

        // POST: MeterReadings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TodayDate,Volume,CustomerName,Nif,CounterName,CounterNumber,Description")] MeterReading meterReading)
        {
            if (ModelState.IsValid)
            {
                _context.Add(meterReading);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            var customerList = _context.Customers.ToList();
            var waterMeterList = _context.WaterMeters.ToList();
            var viewModel = new MeterReadingViewModel
            {
                //Object Area
                MeterReading = new MeterReading(), // Inicializa uma nova instância de Invoice
                Customer = new Customer(), // Inicializa uma nova instância de Customer
               WaterMeter = new WaterMeter(),

               //List Area
               WaterMeters = waterMeterList,
                Customers = customerList // Obtém a lista de clientes
            };

            return View(viewModel);
        }

        // GET: MeterReadings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var meterReading = await _context.MeterReadings.FindAsync(id);
            if (meterReading == null)
            {
                return NotFound();
            }
            return View(meterReading);
        }

        // POST: MeterReadings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TodayDate,Volume,CustomerName,Nif,CounterName,CounterNumber,Description")] MeterReading meterReading)
        {
            if (id != meterReading.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(meterReading);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MeterReadingExists(meterReading.Id))
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
            return View(meterReading);
        }

        // GET: MeterReadings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var meterReading = await _context.MeterReadings
                .FirstOrDefaultAsync(m => m.Id == id);
            if (meterReading == null)
            {
                return NotFound();
            }

            return View(meterReading);
        }

        // POST: MeterReadings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var meterReading = await _context.MeterReadings.FindAsync(id);
            _context.MeterReadings.Remove(meterReading);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MeterReadingExists(int id)
        {
            return _context.MeterReadings.Any(e => e.Id == id);
        }
    }
}
