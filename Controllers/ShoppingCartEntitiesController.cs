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
    public class ShoppingCartEntitiesController : Controller
    {
        private readonly MyDbContext _context;

        public ShoppingCartEntitiesController(MyDbContext context)
        {
            _context = context;
        }

        // GET: ShoppingCartEntities
        public async Task<IActionResult> Index()
        {
            var myDbContext = _context.shoppingCarts.Include(s => s.Customer);
            return View(await myDbContext.ToListAsync());
        }

        // GET: ShoppingCartEntities/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.shoppingCarts == null)
            {
                return NotFound();
            }

            var shoppingCartEntity = await _context.shoppingCarts
                .Include(s => s.Customer)
                .FirstOrDefaultAsync(m => m.CartId == id);
            if (shoppingCartEntity == null)
            {
                return NotFound();
            }

            return View(shoppingCartEntity);
        }

        // GET: ShoppingCartEntities/Create
        public IActionResult Create()
        {
            ViewData["CustomerId"] = new SelectList(_context.Customers, "CustomerId", "FirstName");
            return View();
        }

        // POST: ShoppingCartEntities/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CartId,DateCreated,CustomerId")] ShoppingCartEntity shoppingCartEntity)
        {
            if (!ModelState.IsValid)
            {
                _context.Add(shoppingCartEntity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CustomerId"] = new SelectList(_context.Customers, "CustomerId", "FirstName", shoppingCartEntity.CustomerId);
            return View(shoppingCartEntity);
        }

        // GET: ShoppingCartEntities/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.shoppingCarts == null)
            {
                return NotFound();
            }

            var shoppingCartEntity = await _context.shoppingCarts.FindAsync(id);
            if (shoppingCartEntity == null)
            {
                return NotFound();
            }
            ViewData["CustomerId"] = new SelectList(_context.Customers, "CustomerId", "FirstName", shoppingCartEntity.CustomerId);
            return View(shoppingCartEntity);
        }

        // POST: ShoppingCartEntities/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CartId,DateCreated,CustomerId")] ShoppingCartEntity shoppingCartEntity)
        {
            if (id != shoppingCartEntity.CartId)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                try
                {
                    _context.Update(shoppingCartEntity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ShoppingCartEntityExists(shoppingCartEntity.CartId))
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
            ViewData["CustomerId"] = new SelectList(_context.Customers, "CustomerId", "FirstName", shoppingCartEntity.CustomerId);
            return View(shoppingCartEntity);
        }

        // GET: ShoppingCartEntities/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.shoppingCarts == null)
            {
                return NotFound();
            }

            var shoppingCartEntity = await _context.shoppingCarts
                .Include(s => s.Customer)
                .FirstOrDefaultAsync(m => m.CartId == id);
            if (shoppingCartEntity == null)
            {
                return NotFound();
            }

            return View(shoppingCartEntity);
        }

        // POST: ShoppingCartEntities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.shoppingCarts == null)
            {
                return Problem("Entity set 'MyDbContext.shoppingCarts'  is null.");
            }
            var shoppingCartEntity = await _context.shoppingCarts.FindAsync(id);
            if (shoppingCartEntity != null)
            {
                _context.shoppingCarts.Remove(shoppingCartEntity);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ShoppingCartEntityExists(int id)
        {
            return (_context.shoppingCarts?.Any(e => e.CartId == id)).GetValueOrDefault();
        }
    }
}
