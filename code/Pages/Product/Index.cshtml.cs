using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Fluent_Validation.Data;

namespace Fluent_Validation.Pages.Product
{
    public class IndexModel : PageModel
    {
        private readonly Fluent_Validation.Data.MyDbContext _context;

        public IndexModel(Fluent_Validation.Data.MyDbContext context)
        {
            _context = context;
        }

        public IList<SalesLT_Product> SalesLT_Product { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.SalesLT_Products != null)
            {
                SalesLT_Product = await _context.SalesLT_Products
                .Include(s => s.SalesLT_ProductCategory)
                .Include(s => s.SalesLT_ProductModel).ToListAsync();
            }
        }
    }
}
