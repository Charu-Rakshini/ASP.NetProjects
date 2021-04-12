using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BlogWebsite.Context;
using BlogWebsite.Models;

namespace BlogWebsite.Pages.Blog
{
    public class DeleteModel : PageModel
    {
        private readonly BlogWebsite.Context.DataContext _context;

        public DeleteModel(BlogWebsite.Context.DataContext context)
        {
            _context = context;
        }

        [BindProperty]
        public BlogModel BlogModel { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            BlogModel = await _context.Blogs.FirstOrDefaultAsync(m => m.BlogModelId == id);

            if (BlogModel == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            BlogModel = await _context.Blogs.FindAsync(id);

            if (BlogModel != null)
            {
                _context.Blogs.Remove(BlogModel);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
