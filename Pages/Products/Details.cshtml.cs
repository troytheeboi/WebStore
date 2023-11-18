using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebStore;
using WebStore.Models;

namespace WebStore.Pages.Products
{
    public class DetailsModel : PageModel
    {
        private readonly WebStore.MyDbContext _context;

        public DetailsModel(WebStore.MyDbContext context)
        {
            _context = context;
        }

      public ProductEntity ProductEntity { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Products == null)
            {
                return NotFound();
            }

            var productentity = await _context.Products.FirstOrDefaultAsync(m => m.ProdId == id);
            if (productentity == null)
            {
                return NotFound();
            }
            else 
            {
                ProductEntity = productentity;
            }
            return Page();
        }
    }
}
