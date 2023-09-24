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
            var dataContext = _context.CustomerServices.Include(c => c.ServiceName);
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
                .Include(c => c.ServiceName)
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
            ViewData["ServiceId"] = new SelectList(_context.Service, "Id", "Name");

            var customerList = _context.Customers.ToList();
            var technician = _context.Technicians.ToList();
            var waterMeter = _context.WaterMeters.ToList();

            var viewModel = new CustomerServiceViewModel
            {
                CustomerService = new CustomerService(), // Inicializa uma nova instância de Invoice
                Customer = new Customer(), // Inicializa uma nova instância de Customer
                Technician = new Technician(),
                WaterMeter = new WaterMeter(),


                Customers = customerList, // Obtém a lista de clientes
                Technicians = technician, // Obtém a lista de Tecnicos
                WaterMeters = waterMeter // Obtém a lista de Contadores
            };

            return View(viewModel);
        }

        // POST: CustomerServices/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ServiceId,StartDate,CustomerName,CustomerAdress,Nif,PhoneNumber,Status,TechnicianName,TechnicianPhone,WaterMeterName,WaterMeterNumber")] CustomerService customerService)
        {
            if (ModelState.IsValid)
            {
                _context.Add(customerService);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ServiceId"] = new SelectList(_context.Service, "Id", "Name", customerService.ServiceId);

            var customerList = _context.Customers.ToList();
            var technician = _context.Technicians.ToList();
            var waterMeter = _context.WaterMeters.ToList();

            var viewModel = new CustomerServiceViewModel
            {
                CustomerService = new CustomerService(), // Inicializa uma nova instância de Invoice
                Customer = new Customer(), // Inicializa uma nova instância de Customer
                Technician = new Technician(),
                WaterMeter= new WaterMeter(),   


                Customers = customerList, // Obtém a lista de clientes
                Technicians = technician, // Obtém a lista de Tecnicos
                WaterMeters = waterMeter // Obtém a lista de Contadores
            };

            return View(viewModel);
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
            ViewData["ServiceId"] = new SelectList(_context.Service, "Id", "Name", customerService.ServiceId);
            return View(customerService);
        }

        // POST: CustomerServices/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ServiceId,StartDate,CustomerName,CustomerAdress,Nif,PhoneNumber,Status,TechnicianName,TechnicianPhone,WaterMeterName,WaterMeterNumber")] CustomerService customerService)
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
            ViewData["ServiceId"] = new SelectList(_context.Service, "Id", "Name", customerService.ServiceId);
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
                .Include(c => c.ServiceName)
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
