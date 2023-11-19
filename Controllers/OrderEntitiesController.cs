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
    public class OrderEntitiesController : Controller
    {
        private readonly MyDbContext _context;

        public OrderEntitiesController(MyDbContext context)
        {
            _context = context;
        }

        // GET: OrderEntities
        public async Task<IActionResult> Index()
        {
            var myDbContext = _context.Orders.Include(o => o.customer);
            return View(await myDbContext.ToListAsync());
        }

        // GET: OrderEntities/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Orders == null)
            {
                return NotFound();
            }

            var orderEntity = await _context.Orders
                .Include(o => o.customer)
                .FirstOrDefaultAsync(m => m.OrderId == id);
            if (orderEntity == null)
            {
                return NotFound();
            }

            return View(orderEntity);
        }

        // GET: OrderEntities/Create
        public IActionResult Create()
        {
            ViewData["CustomerId"] = new SelectList(_context.Customers, "CustomerId", "FirstName");
            return View();
        }

        // POST: OrderEntities/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OrderId,OrderDate,Total,CustomerId,Status")] OrderEntity orderEntity)
        {
            if (!ModelState.IsValid)
            {
                _context.Add(orderEntity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CustomerId"] = new SelectList(_context.Customers, "CustomerId", "FirstName", orderEntity.CustomerId);
            return View(orderEntity);
        }

        // GET: OrderEntities/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Orders == null)
            {
                return NotFound();
            }

            var orderEntity = await _context.Orders.FindAsync(id);
            if (orderEntity == null)
            {
                return NotFound();
            }
            ViewData["CustomerId"] = new SelectList(_context.Customers, "CustomerId", "FirstName", orderEntity.CustomerId);
            return View(orderEntity);
        }

        // POST: OrderEntities/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OrderId,OrderDate,Total,CustomerId,Status")] OrderEntity orderEntity)
        {
            if (id != orderEntity.OrderId)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                try
                {
                    _context.Update(orderEntity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrderEntityExists(orderEntity.OrderId))
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
            ViewData["CustomerId"] = new SelectList(_context.Customers, "CustomerId", "FirstName", orderEntity.CustomerId);
            return View(orderEntity);
        }

        // GET: OrderEntities/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Orders == null)
            {
                return NotFound();
            }

            var orderEntity = await _context.Orders
                .Include(o => o.customer)
                .FirstOrDefaultAsync(m => m.OrderId == id);
            if (orderEntity == null)
            {
                return NotFound();
            }

            return View(orderEntity);
        }

        // POST: OrderEntities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Orders == null)
            {
                return Problem("Entity set 'MyDbContext.Orders'  is null.");
            }
            var orderEntity = await _context.Orders.FindAsync(id);
            if (orderEntity != null)
            {
                _context.Orders.Remove(orderEntity);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrderEntityExists(int id)
        {
            return (_context.Orders?.Any(e => e.OrderId == id)).GetValueOrDefault();
        }
    }
}
