using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BlogWebsite.Context;
using BlogWebsite.Models;

namespace BlogWebsite.Pages.Author
{
    public class EditModel : PageModel
    {
        private readonly BlogWebsite.Context.DataContext _context;

        public EditModel(BlogWebsite.Context.DataContext context)
        {
            _context = context;
        }

        [BindProperty]
        public AuthorModel AuthorModel { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            AuthorModel = await _context.Authors.FirstOrDefaultAsync(m => m.AuthorModelId == id);

            if (AuthorModel == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(AuthorModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AuthorModelExists(AuthorModel.AuthorModelId))
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

        private bool AuthorModelExists(Guid id)
        {
            return _context.Authors.Any(e => e.AuthorModelId == id);
        }
    }
}
