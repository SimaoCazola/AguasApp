﻿using System;
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
    public class ContractsController : Controller
    {
        private readonly DataContext _context;

        public ContractsController(DataContext context)
        {
            _context = context;
        }

        // GET: Contracts
        public async Task<IActionResult> Index()
        {
            return View(await _context.Contracts.ToListAsync());
            
        }


        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contract = await _context.Contracts
                .FirstOrDefaultAsync(m => m.Id == id);

            if (contract == null)
            {
                return NotFound();
            }

            return View(contract);
        }




        // GET: Contracts/Create
        public IActionResult Create()
        {
            var customerList = _context.Customers.ToList();

            var viewModel = new ContractViewModel
            {
                Contract = new Contract(), // Inicializa uma nova instância de Contratos
                Customer = new Customer(), // Inicializa uma nova instância de Customer
               

                Customers = customerList, // Obtém a lista de clientes 
            };
            return View(viewModel);
        }

        // POST: Contracts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ContractNumber,Nif,CustomerNameId,StartDate,EndDate,ContractDuration,IsActive")] Contract contract)
        {
            if (ModelState.IsValid)
            {
                _context.Add(contract);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            var customerList = _context.Customers.ToList();

            var viewModel = new ContractViewModel
            {
                Contract = contract, // Inicializa uma nova instância de Contratos
                Customer = new Customer(), // Inicializa uma nova instância de Customer

                Customers = customerList, // Obtém a lista de clientes 
            };
            return View(viewModel);
        }

        // GET: Contracts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contract = await _context.Contracts.FindAsync(id);
            if (contract == null)
            {
                return NotFound();
            }
           
            return View(contract);
        }

        // POST: Contracts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ContractNumber,Nif,CustomerNameId,StartDate,EndDate,ContractDuration,IsActive")] Contract contract)
        {
            if (id != contract.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(contract);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContractExists(contract.Id))
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
           
            return View(contract);
        }

        // GET: Contracts/Delete/5
        
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contract = await _context.Contracts
                .FirstOrDefaultAsync(m => m.Id == id);

            if (contract == null)
            {
                return NotFound();
            }

            return View(contract);
        }



        // POST: Contracts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var contract = await _context.Contracts.FindAsync(id);
            _context.Contracts.Remove(contract);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ContractExists(int id)
        {
            return _context.Contracts.Any(e => e.Id == id);
        }
    }
}
