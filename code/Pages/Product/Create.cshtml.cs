using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Fluent_Validation.Data;

namespace Fluent_Validation.Pages.Product
{
    public class CreateModel : PageModel
    {
        private readonly Fluent_Validation.Data.MyDbContext _context;

        public CreateModel(Fluent_Validation.Data.MyDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["ProductCategoryId"] = new SelectList(_context.SalesLT_ProductCategories, "ProductCategoryId", "Name");
        ViewData["ProductModelId"] = new SelectList(_context.SalesLT_ProductModels, "ProductModelId", "Name");
            return Page();
        }

        [BindProperty]
        public SalesLT_Product SalesLT_Product { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.SalesLT_Products == null || SalesLT_Product == null)
            {
                return Page();
            }

            _context.SalesLT_Products.Add(SalesLT_Product);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
