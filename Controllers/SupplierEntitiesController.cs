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
    public class SupplierEntitiesController : Controller
    {
        private readonly MyDbContext _context;

        public SupplierEntitiesController(MyDbContext context)
        {
            _context = context;
        }

        // GET: SupplierEntities
        public async Task<IActionResult> Index()
        {
            return _context.Suppliers != null ?
                        View(await _context.Suppliers.ToListAsync()) :
                        Problem("Entity set 'MyDbContext.Suppliers'  is null.");
        }

        // GET: SupplierEntities/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Suppliers == null)
            {
                return NotFound();
            }

            var supplierEntity = await _context.Suppliers
                .FirstOrDefaultAsync(m => m.supplierId == id);
            if (supplierEntity == null)
            {
                return NotFound();
            }

            return View(supplierEntity);
        }

        // GET: SupplierEntities/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SupplierEntities/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("supplierId,supplierName,phoneNumber,supplierAddress")] SupplierEntity supplierEntity)
        {
            if (!ModelState.IsValid)
            {
                _context.Add(supplierEntity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(supplierEntity);
        }

        // GET: SupplierEntities/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Suppliers == null)
            {
                return NotFound();
            }

            var supplierEntity = await _context.Suppliers.FindAsync(id);
            if (supplierEntity == null)
            {
                return NotFound();
            }
            return View(supplierEntity);
        }

        // POST: SupplierEntities/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("supplierId,supplierName,phoneNumber,supplierAddress")] SupplierEntity supplierEntity)
        {
            if (id != supplierEntity.supplierId)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                try
                {
                    _context.Update(supplierEntity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SupplierEntityExists(supplierEntity.supplierId))
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
            return View(supplierEntity);
        }

        // GET: SupplierEntities/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Suppliers == null)
            {
                return NotFound();
            }

            var supplierEntity = await _context.Suppliers
                .FirstOrDefaultAsync(m => m.supplierId == id);
            if (supplierEntity == null)
            {
                return NotFound();
            }

            return View(supplierEntity);
        }

        // POST: SupplierEntities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Suppliers == null)
            {
                return Problem("Entity set 'MyDbContext.Suppliers'  is null.");
            }
            var supplierEntity = await _context.Suppliers.FindAsync(id);
            if (supplierEntity != null)
            {
                _context.Suppliers.Remove(supplierEntity);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SupplierEntityExists(int id)
        {
            return (_context.Suppliers?.Any(e => e.supplierId == id)).GetValueOrDefault();
        }
    }
}
