using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Fluent_Validation.Data;
using FluentValidation;

namespace Fluent_Validation.Pages.Product
{
    public class EditModel : PageModel
    {
        private readonly Fluent_Validation.Data.MyDbContext _context;
        private IValidator<SalesLT_Product> _validator;

        public EditModel(Fluent_Validation.Data.MyDbContext context, IValidator<SalesLT_Product> validator)
        {
            _context = context;
            _validator = validator;
        }

        [BindProperty]
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
            SalesLT_Product = saleslt_product;
            ViewData["ProductCategoryId"] = new SelectList(_context.SalesLT_ProductCategories, "ProductCategoryId", "Name");
            ViewData["ProductModelId"] = new SelectList(_context.SalesLT_ProductModels, "ProductModelId", "Name");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            var result = await _validator.ValidateAsync(SalesLT_Product);
            if (!result.IsValid) result.AddToModelState(ModelState, nameof(SalesLT_Product));

            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(SalesLT_Product).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SalesLT_ProductExists(SalesLT_Product.ProductId))
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

        private bool SalesLT_ProductExists(int id)
        {
            return (_context.SalesLT_Products?.Any(e => e.ProductId == id)).GetValueOrDefault();
        }
    }
}
