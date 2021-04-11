using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BlogWebsite.Context;
using BlogWebsite.Models;

namespace BlogWebsite.Pages.Blog
{
    public class CreateModel : PageModel
    {
        private readonly BlogWebsite.Context.DataContext _context;

        public CreateModel(BlogWebsite.Context.DataContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public BlogModel BlogModel { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Blogs.Add(BlogModel);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
