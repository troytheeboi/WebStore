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
        ViewData["SupplierID"] = new SelectList(_context.Suppliers, "supplierId", "supplierId");
            return Page();
        }

        [BindProperty]
        public Product Product { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (/*!ModelState.IsValid || */_context.Products == null || Product == null)
            {
                Console.WriteLine("here");
                Console.WriteLine(ModelState.IsValid);
                Console.WriteLine(_context.Products==null);
                Console.WriteLine(Product==null);
                return Page();
            }

            Console.WriteLine("here1");

            _context.Products.Add(Product);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
