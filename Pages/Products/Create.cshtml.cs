using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebStore;
using WebStore.Models;

namespace WebStore.Pages.Products
{
    public class CreateModel : PageModel
    {
        private readonly WebStore.MyDbContext _context;

        public CreateModel(WebStore.MyDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["CategoryID"] = new SelectList(_context.Categories, "CatId", "CatDescription");
        ViewData["SupplierID"] = new SelectList(_context.Suppliers, "supplierId", "supplierName");
            return Page();
        }

        [BindProperty]
        public ProductEntity ProductEntity { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (/*!ModelState.IsValid ||*/ _context.Products == null || ProductEntity == null)
            {
                return Page();
            }

            _context.Products.Add(ProductEntity);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
