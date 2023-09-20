using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AguasApp.Data;
using AguasApp.Data.Entities;

namespace AguasApp.Controllers
{
    public class CustomerServicesController : Controller
    {
        private readonly DataContext _context;

        public CustomerServicesController(DataContext context)
        {
            _context = context;
        }

        // GET: CustomerServices
        public async Task<IActionResult> Index()
        {
            var dataContext = _context.CustomerServices.Include(c => c.CustomerName).Include(c => c.Technician).Include(c => c.WaterMeter);
            return View(await dataContext.ToListAsync());
        }

        // GET: CustomerServices/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customerService = await _context.CustomerServices
                .Include(c => c.CustomerName)
                .Include(c => c.Technician)
                .Include(c => c.WaterMeter)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (customerService == null)
            {
                return NotFound();
            }

            return View(customerService);
        }

        // GET: CustomerServices/Create
        public IActionResult Create()
        {
            ViewData["CustomerNameId"] = new SelectList(_context.Customers, "Id", "FullName");
            ViewData["TechnicianId"] = new SelectList(_context.Technicians, "Id", "FullName");
            ViewData["WaterMeterId"] = new SelectList(_context.WaterMeters, "Id", "Name");
            return View();
        }

        // POST: CustomerServices/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ServiceDescription,DateTimeOpened,StartDate,CustomerNameId,CustomerAdress,Nif,PhoneNumber,Status,TechnicianId,WaterMeterId")] CustomerService customerService)
        {
            if (ModelState.IsValid)
            {
                _context.Add(customerService);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CustomerNameId"] = new SelectList(_context.Customers, "Id", "FullName", customerService.CustomerNameId);
            ViewData["TechnicianId"] = new SelectList(_context.Technicians, "Id", "FullName", customerService.TechnicianId);
            ViewData["WaterMeterId"] = new SelectList(_context.WaterMeters, "Id", "Name", customerService.WaterMeterId);
            return View(customerService);
        }

        // GET: CustomerServices/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customerService = await _context.CustomerServices.FindAsync(id);
            if (customerService == null)
            {
                return NotFound();
            }
            ViewData["CustomerNameId"] = new SelectList(_context.Customers, "Id", "FullName", customerService.CustomerNameId);
            ViewData["TechnicianId"] = new SelectList(_context.Technicians, "Id", "FullName", customerService.TechnicianId);
            ViewData["WaterMeterId"] = new SelectList(_context.WaterMeters, "Id", "Name", customerService.WaterMeterId);
            return View(customerService);
        }

        // POST: CustomerServices/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ServiceDescription,DateTimeOpened,StartDate,CustomerNameId,CustomerAdress,Nif,PhoneNumber,Status,TechnicianId,WaterMeterId")] CustomerService customerService)
        {
            if (id != customerService.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(customerService);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CustomerServiceExists(customerService.Id))
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
            ViewData["CustomerNameId"] = new SelectList(_context.Customers, "Id", "FullName", customerService.CustomerNameId);
            ViewData["TechnicianId"] = new SelectList(_context.Technicians, "Id", "FullName", customerService.TechnicianId);
            ViewData["WaterMeterId"] = new SelectList(_context.WaterMeters, "Id", "Name", customerService.WaterMeterId);
            return View(customerService);
        }

        // GET: CustomerServices/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customerService = await _context.CustomerServices
                .Include(c => c.CustomerName)
                .Include(c => c.Technician)
                .Include(c => c.WaterMeter)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (customerService == null)
            {
                return NotFound();
            }

            return View(customerService);
        }

        // POST: CustomerServices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var customerService = await _context.CustomerServices.FindAsync(id);
            _context.CustomerServices.Remove(customerService);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CustomerServiceExists(int id)
        {
            return _context.CustomerServices.Any(e => e.Id == id);
        }
    }
}
