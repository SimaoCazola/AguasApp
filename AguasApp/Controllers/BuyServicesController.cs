using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AguasApp.Data;
using AguasApp.Data.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using AguasApp.Helpers;

namespace AguasApp.Controllers
{
    [Authorize]
    public class BuyServicesController : Controller
    {
        private readonly DataContext _context;
        private readonly IUserHelper _userHelper;

        public BuyServicesController(DataContext context, IUserHelper userHelper)
        {
            _context = context;
            _userHelper = userHelper;
        }

        /*________________INDEX______________________________*/
        // INDEX COM USER LOGADO ASSOCIADO
        public async Task<IActionResult> Index()
        {
            var user = User.Identity.Name; // GUARDAR O USER LOGADO NA VARIAVEL user

            var dataContext = _context.BuyServices
                .Where(b => b.User == user) // Filtre apenas BuyServices associados ao usuário logado
                .Include(b => b.Service);

            return View(await dataContext.ToListAsync());
        }
        /*_______________CLOSE iNDEX____________________________*/

        // GET: BuyServices/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var buyService = await _context.BuyServices
                .Include(b => b.Service)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (buyService == null)
            {
                return NotFound();
            }

            return View(buyService);
        }

        // GET: BuyServices/Create
        public IActionResult Create()
        {
            ViewData["ServiceId"] = new SelectList(_context.Service, "Id", "Name");
            return View();
        }

        public IActionResult ConfirmOrder() 
        {
          
            return View();
        }
        /*_____________CREATE POST COM USER ASSOCIADO LOGADO___________________________*/

        // CREATE COM USER LOGADO ASSOCIADO
        // POST: BuyServices/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.  
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ServiceId,Description,Mobile,Email,Adress")] BuyService buyService)
        {
            if (ModelState.IsValid)
            {
                // Associe a propriedade User do BuyService ao nome de usuário do usuário logado
                buyService.User = User.Identity.Name; // ATRIBUIR O  User.Identity.Name LOGADO NA PROPRIEDADE User

                _context.Add(buyService);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(ConfirmOrder));
            }

            ViewData["ServiceId"] = new SelectList(_context.Service, "Id", "Name", buyService.ServiceId);
            return View(buyService);
        }
        /*__________CREATE POST CLOSE_______________________________*/



        // GET: BuyServices/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var buyService = await _context.BuyServices.FindAsync(id);
            if (buyService == null)
            {
                return NotFound();
            }
            ViewData["ServiceId"] = new SelectList(_context.Service, "Id", "Name", buyService.ServiceId);
            return View(buyService);
        }

        // POST: BuyServices/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ServiceId,Description,Mobile,Email,Adress")] BuyService buyService)
        {
            if (id != buyService.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(buyService);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BuyServiceExists(buyService.Id))
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
            ViewData["ServiceId"] = new SelectList(_context.Service, "Id", "Name", buyService.ServiceId);
            return View(buyService);
        }

        // GET: BuyServices/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var buyService = await _context.BuyServices
                .Include(b => b.Service)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (buyService == null)
            {
                return NotFound();
            }

            return View(buyService);
        }

        // POST: BuyServices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var buyService = await _context.BuyServices.FindAsync(id);
            _context.BuyServices.Remove(buyService);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BuyServiceExists(int id)
        {
            return _context.BuyServices.Any(e => e.Id == id);
        }
    }
}
