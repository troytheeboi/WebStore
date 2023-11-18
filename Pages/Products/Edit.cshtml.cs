using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebStore;
using WebStore.Models;

namespace WebStore.Pages.Products
{
    public class EditModel : PageModel
    {
        private readonly WebStore.MyDbContext _context;

        public EditModel(WebStore.MyDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ProductEntity ProductEntity { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Products == null)
            {
                return NotFound();
            }

            var productentity =  await _context.Products.FirstOrDefaultAsync(m => m.ProdId == id);
            if (productentity == null)
            {
                return NotFound();
            }
            ProductEntity = productentity;
           ViewData["CategoryID"] = new SelectList(_context.Categories, "CatId", "CatDescription");
           ViewData["SupplierID"] = new SelectList(_context.Suppliers, "supplierId", "supplierName");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
        /*    if (!ModelState.IsValid)
            {
                return Page();
            }*/

            _context.Attach(ProductEntity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductEntityExists(ProductEntity.ProdId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ProductEntityExists(int id)
        {
          return (_context.Products?.Any(e => e.ProdId == id)).GetValueOrDefault();
        }
    }
}
