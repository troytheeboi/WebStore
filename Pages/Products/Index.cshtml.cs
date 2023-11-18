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
    public class IndexModel : PageModel
    {
        private readonly WebStore.MyDbContext _context;

        public IndexModel(WebStore.MyDbContext context)
        {
            _context = context;
        }

        public IList<ProductEntity> ProductEntity { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Products != null)
            {
                ProductEntity = await _context.Products
                .Include(p => p.category)
                .Include(p => p.supplier).ToListAsync();
            }
        }
    }
}
