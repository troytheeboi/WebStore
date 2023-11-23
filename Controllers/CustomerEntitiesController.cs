using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebStore.Models;

namespace WebStore.Controllers
{
    public class CustomerEntitiesController : Controller
    {
        private readonly MyDbContext _context;

        public CustomerEntitiesController(MyDbContext context)
        {
            _context = context;
        }

        // GET: CustomerEntities
        public async Task<IActionResult> Index()
        {
            return _context.Customers != null ?
                        View(await _context.Customers.ToListAsync()) :
                        Problem("Entity set 'MyDbContext.Customers'  is null.");
        }

        // GET: CustomerEntities/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Customers == null)
            {
                return NotFound();
            }

            var customerEntity = await _context.Customers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (customerEntity == null)
            {
                return NotFound();
            }

            return View(customerEntity);
        }

        // GET: CustomerEntities/Create
/*        [Route("CustomerEntities/cr")]
*/        public IActionResult Create()
        {
            return View();
        }

        // POST: CustomerEntities/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,Phone")] CustomerEntity customerEntity)
        {
            if (true)
            {
                _context.Add(customerEntity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(customerEntity);
        }

        // GET: CustomerEntities/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Customers == null)
            {
                return NotFound();
            }

            var customerEntity = await _context.Customers.FindAsync(id);
            if (customerEntity == null)
            {
                return NotFound();
            }
            return View(customerEntity);
        }

        // POST: CustomerEntities/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,Phone")] CustomerEntity customerEntity)
        {
            if (id != customerEntity.Id)
            {
                return NotFound();
            }

            if (true)
            {
                try
                {
                    _context.Update(customerEntity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CustomerEntityExists(customerEntity.Id))
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
            return View(customerEntity);
        }

        // GET: CustomerEntities/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Customers == null)
            {
                return NotFound();
            }

            var customerEntity = await _context.Customers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (customerEntity == null)
            {
                return NotFound();
            }

            return View(customerEntity);
        }

        // POST: CustomerEntities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Customers == null)
            {
                return Problem("Entity set 'MyDbContext.Customers'  is null.");
            }
            var customerEntity = await _context.Customers.FindAsync(id);
            if (customerEntity != null)
            {
                _context.Customers.Remove(customerEntity);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CustomerEntityExists(int id)
        {
            return (_context.Customers?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
