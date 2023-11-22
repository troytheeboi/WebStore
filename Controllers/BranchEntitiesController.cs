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
    public class BranchEntitiesController : Controller
    {
        private readonly MyDbContext _context;

        public BranchEntitiesController(MyDbContext context)
        {
            _context = context;
        }

        // GET: BranchEntities
        public async Task<IActionResult> Index()
        {
            return _context.branches != null ?
                        View(await _context.branches.ToListAsync()) :
                        Problem("Entity set 'MyDbContext.branches'  is null.");
        }

        // GET: BranchEntities/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.branches == null)
            {
                return NotFound();
            }

            var branchEntity = await _context.branches
                .FirstOrDefaultAsync(m => m.Id == id);
            if (branchEntity == null)
            {
                return NotFound();
            }

            return View(branchEntity);
        }

        // GET: BranchEntities/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BranchEntities/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Location,capacity,ManagerID")] BranchEntity branchEntity)
        {
            if (true)
            {
                _context.Add(branchEntity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(branchEntity);
        }

        // GET: BranchEntities/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.branches == null)
            {
                return NotFound();
            }

            var branchEntity = await _context.branches.FindAsync(id);
            if (branchEntity == null)
            {
                return NotFound();
            }
            return View(branchEntity);
        }

        // POST: BranchEntities/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Location,capacity,ManagerID")] BranchEntity branchEntity)
        {
            if (id != branchEntity.Id)
            {
                return NotFound();
            }

            if (true)
            {
                try
                {
                    _context.Update(branchEntity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BranchEntityExists(branchEntity.Id))
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
            return View(branchEntity);
        }

        // GET: BranchEntities/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.branches == null)
            {
                return NotFound();
            }

            var branchEntity = await _context.branches
                .FirstOrDefaultAsync(m => m.Id == id);
            if (branchEntity == null)
            {
                return NotFound();
            }

            return View(branchEntity);
        }

        // POST: BranchEntities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.branches == null)
            {
                return Problem("Entity set 'MyDbContext.branches'  is null.");
            }
            var branchEntity = await _context.branches.FindAsync(id);
            if (branchEntity != null)
            {
                _context.branches.Remove(branchEntity);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BranchEntityExists(int id)
        {
            return (_context.branches?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
