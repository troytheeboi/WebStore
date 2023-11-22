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
    public class ProductEntitiesController : Controller
    {
        private readonly MyDbContext _context;

        public ProductEntitiesController(MyDbContext context)
        {
            _context = context;
        }

        // GET: ProductEntities
        public async Task<IActionResult> Index()
        {
            var myDbContext = _context.Products.Include(p => p.branch).Include(p => p.category).Include(p => p.supplier);
            return View(await myDbContext.ToListAsync());
        }

        // GET: ProductEntities/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Products == null)
            {
                return NotFound();
            }

            var productEntity = await _context.Products
                .Include(p => p.branch)
                .Include(p => p.category)
                .Include(p => p.supplier)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (productEntity == null)
            {
                return NotFound();
            }

            return View(productEntity);
        }

        // GET: ProductEntities/Create
        public IActionResult Create()
        {
            ViewData["BranchID"] = new SelectList(_context.branches, "Id", "Location");
            ViewData["CategoryID"] = new SelectList(_context.Categories, "Id", "CatDescription");
            ViewData["SupplierID"] = new SelectList(_context.Suppliers, "Id", "Id");
            return View();
        }

        // POST: ProductEntities/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProdName,Price,CategoryID,SupplierID,BranchID,CreatedAt,LastModified,EmployeeId,Id")] ProductEntity productEntity)
        {
            if (!ModelState.IsValid)
            {
                _context.Add(productEntity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BranchID"] = new SelectList(_context.branches, "Id", "Location", productEntity.BranchID);
            ViewData["CategoryID"] = new SelectList(_context.Categories, "Id", "CatDescription", productEntity.CategoryID);
            ViewData["SupplierID"] = new SelectList(_context.Suppliers, "Id", "Id", productEntity.SupplierID);
            return View(productEntity);
        }

        // GET: ProductEntities/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Products == null)
            {
                return NotFound();
            }

            var productEntity = await _context.Products.FindAsync(id);
            if (productEntity == null)
            {
                return NotFound();
            }
            ViewData["BranchID"] = new SelectList(_context.branches, "Id", "Location", productEntity.BranchID);
            ViewData["CategoryID"] = new SelectList(_context.Categories, "Id", "CatDescription", productEntity.CategoryID);
            ViewData["SupplierID"] = new SelectList(_context.Suppliers, "Id", "Id", productEntity.SupplierID);
            return View(productEntity);
        }

        // POST: ProductEntities/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProdName,Price,CategoryID,SupplierID,BranchID,CreatedAt,LastModified,EmployeeId,Id")] ProductEntity productEntity)
        {
            if (id != productEntity.Id)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                try
                {
                    _context.Update(productEntity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductEntityExists(productEntity.Id))
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
            ViewData["BranchID"] = new SelectList(_context.branches, "Id", "Location", productEntity.BranchID);
            ViewData["CategoryID"] = new SelectList(_context.Categories, "Id", "CatDescription", productEntity.CategoryID);
            ViewData["SupplierID"] = new SelectList(_context.Suppliers, "Id", "Id", productEntity.SupplierID);
            return View(productEntity);
        }

        // GET: ProductEntities/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Products == null)
            {
                return NotFound();
            }

            var productEntity = await _context.Products
                .Include(p => p.branch)
                .Include(p => p.category)
                .Include(p => p.supplier)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (productEntity == null)
            {
                return NotFound();
            }

            return View(productEntity);
        }

        // POST: ProductEntities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Products == null)
            {
                return Problem("Entity set 'MyDbContext.Products'  is null.");
            }
            var productEntity = await _context.Products.FindAsync(id);
            if (productEntity != null)
            {
                _context.Products.Remove(productEntity);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductEntityExists(int id)
        {
            return (_context.Products?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
