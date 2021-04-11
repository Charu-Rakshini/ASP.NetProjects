using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BlogWebsite.Context;
using BlogWebsite.Models;

namespace BlogWebsite.Pages.Author
{
    public class DetailsModel : PageModel
    {
        private readonly BlogWebsite.Context.DataContext _context;

        public DetailsModel(BlogWebsite.Context.DataContext context)
        {
            _context = context;
        }

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
    }
}
