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
    public class InvoicesController : Controller
    {
        private readonly DataContext _context;

        public InvoicesController(DataContext context)
        {
            _context = context;
        }

        // GET: Invoices
        public async Task<IActionResult> Index()
        {
            return View(await _context.Invoices.ToListAsync());
        }

        // GET: Invoices/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var invoice = await _context.Invoices
                .FirstOrDefaultAsync(m => m.Id == id);
            if (invoice == null)
            {
                return NotFound();
            }

            return View(invoice);
        }

        public async Task<IActionResult> Create()
        {
            var customerList = _context.Customers.ToList();

            var viewModel = new InvoiceConsumptionViewModel
            {
                Invoice = new Invoice(), // Inicializa uma nova instância de Invoice
                Customer = new Customer(), // Inicializa uma nova instância de Customer
                Customers = customerList // Obtém a lista de clientes
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FullName,Nif,Address,InvoiceNumber,Scalation,Descriptions,Price,Volume,LastReadingDate,DueDate,Status,Reference,Entity")] Invoice invoice)
        {
            if (ModelState.IsValid)
            {
                // Adicione a nova fatura ao contexto e salve no banco de dados
                _context.Add(invoice);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            // Se o modelo não for válido, você pode repetir a lógica de criação da ViewModel aqui
            var customerList = _context.Customers.ToList();

            var viewModel = new InvoiceConsumptionViewModel
            {
                Invoice = invoice, // Preencha a ViewModel com a instância de invoice
                Customer = new Customer(), // Inicializa uma nova instância de Customer
                Customers = customerList // Obtém a lista de clientes
            };

            return View(viewModel);
        }


        // GET: Invoices/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var invoice = await _context.Invoices.FindAsync(id);
            if (invoice == null)
            {
                return NotFound();
            }
            return View(invoice);
        }

        // POST: Invoices/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FullName,Nif,Address,InvoiceNumber,Scalation,Descriptions,Price,Volume,LastReadingDate,DueDate,Status,Reference,Entity")] Invoice invoice)
        {
            if (id != invoice.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(invoice);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InvoiceExists(invoice.Id))
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
            return View(invoice);
        }

        // GET: Invoices/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var invoice = await _context.Invoices
                .FirstOrDefaultAsync(m => m.Id == id);
            if (invoice == null)
            {
                return NotFound();
            }

            return View(invoice);
        }

        // POST: Invoices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var invoice = await _context.Invoices.FindAsync(id);
            _context.Invoices.Remove(invoice);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InvoiceExists(int id)
        {
            return _context.Invoices.Any(e => e.Id == id);
        }
    }
}
