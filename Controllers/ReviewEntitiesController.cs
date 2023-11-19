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
    public class ReviewEntitiesController : Controller
    {
        private readonly MyDbContext _context;

        public ReviewEntitiesController(MyDbContext context)
        {
            _context = context;
        }

        // GET: ReviewEntities
        public async Task<IActionResult> Index()
        {
            return _context.reviews != null ?
                        View(await _context.reviews.ToListAsync()) :
                        Problem("Entity set 'MyDbContext.reviews'  is null.");
        }

        // GET: ReviewEntities/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.reviews == null)
            {
                return NotFound();
            }

            var reviewEntity = await _context.reviews
                .FirstOrDefaultAsync(m => m.ReviewId == id);
            if (reviewEntity == null)
            {
                return NotFound();
            }

            return View(reviewEntity);
        }

        // GET: ReviewEntities/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ReviewEntities/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ReviewId,ReviewTime,Status")] ReviewEntity reviewEntity)
        {
            if (!ModelState.IsValid)
            {
                _context.Add(reviewEntity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(reviewEntity);
        }

        // GET: ReviewEntities/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.reviews == null)
            {
                return NotFound();
            }

            var reviewEntity = await _context.reviews.FindAsync(id);
            if (reviewEntity == null)
            {
                return NotFound();
            }
            return View(reviewEntity);
        }

        // POST: ReviewEntities/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ReviewId,ReviewTime,Status")] ReviewEntity reviewEntity)
        {
            if (id != reviewEntity.ReviewId)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                try
                {
                    _context.Update(reviewEntity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReviewEntityExists(reviewEntity.ReviewId))
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
            return View(reviewEntity);
        }

        // GET: ReviewEntities/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.reviews == null)
            {
                return NotFound();
            }

            var reviewEntity = await _context.reviews
                .FirstOrDefaultAsync(m => m.ReviewId == id);
            if (reviewEntity == null)
            {
                return NotFound();
            }

            return View(reviewEntity);
        }

        // POST: ReviewEntities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.reviews == null)
            {
                return Problem("Entity set 'MyDbContext.reviews'  is null.");
            }
            var reviewEntity = await _context.reviews.FindAsync(id);
            if (reviewEntity != null)
            {
                _context.reviews.Remove(reviewEntity);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReviewEntityExists(int id)
        {
            return (_context.reviews?.Any(e => e.ReviewId == id)).GetValueOrDefault();
        }
    }
}
