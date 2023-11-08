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
    public class DetailsModel : PageModel
    {
        private readonly Fluent_Validation.Data.MyDbContext _context;

        public DetailsModel(Fluent_Validation.Data.MyDbContext context)
        {
            _context = context;
        }

      public SalesLT_Product SalesLT_Product { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.SalesLT_Products == null)
            {
                return NotFound();
            }

            var saleslt_product = await _context.SalesLT_Products.FirstOrDefaultAsync(m => m.ProductId == id);
            if (saleslt_product == null)
            {
                return NotFound();
            }
            else 
            {
                SalesLT_Product = saleslt_product;
            }
            return Page();
        }
    }
}
