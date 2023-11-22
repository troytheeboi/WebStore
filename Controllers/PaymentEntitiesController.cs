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
    public class PaymentEntitiesController : Controller
    {
        private readonly MyDbContext _context;

        public PaymentEntitiesController(MyDbContext context)
        {
            _context = context;
        }

        // GET: PaymentEntities
        public async Task<IActionResult> Index()
        {
            return _context.payments != null ?
                        View(await _context.payments.ToListAsync()) :
                        Problem("Entity set 'MyDbContext.payments'  is null.");
        }

        // GET: PaymentEntities/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.payments == null)
            {
                return NotFound();
            }

            var paymentEntity = await _context.payments
                .FirstOrDefaultAsync(m => m.Id == id);
            if (paymentEntity == null)
            {
                return NotFound();
            }

            return View(paymentEntity);
        }

        // GET: PaymentEntities/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PaymentEntities/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Amount,PaymentDate,PaymentMethod")] PaymentEntity paymentEntity)
        {
            if (!ModelState.IsValid)
            {
                _context.Add(paymentEntity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(paymentEntity);
        }

        // GET: PaymentEntities/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.payments == null)
            {
                return NotFound();
            }

            var paymentEntity = await _context.payments.FindAsync(id);
            if (paymentEntity == null)
            {
                return NotFound();
            }
            return View(paymentEntity);
        }

        // POST: PaymentEntities/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Amount,PaymentDate,PaymentMethod")] PaymentEntity paymentEntity)
        {
            if (id != paymentEntity.Id)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                try
                {
                    _context.Update(paymentEntity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PaymentEntityExists(paymentEntity.Id))
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
            return View(paymentEntity);
        }

        // GET: PaymentEntities/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.payments == null)
            {
                return NotFound();
            }

            var paymentEntity = await _context.payments
                .FirstOrDefaultAsync(m => m.Id == id);
            if (paymentEntity == null)
            {
                return NotFound();
            }

            return View(paymentEntity);
        }

        // POST: PaymentEntities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.payments == null)
            {
                return Problem("Entity set 'MyDbContext.payments'  is null.");
            }
            var paymentEntity = await _context.payments.FindAsync(id);
            if (paymentEntity != null)
            {
                _context.payments.Remove(paymentEntity);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PaymentEntityExists(int id)
        {
            return (_context.payments?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
