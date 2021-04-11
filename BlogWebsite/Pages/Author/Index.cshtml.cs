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
    public class IndexModel : PageModel
    {
        private readonly BlogWebsite.Context.DataContext _context;

        public IndexModel(BlogWebsite.Context.DataContext context)
        {
            _context = context;
        }

        public IList<AuthorModel> AuthorModel { get;set; }

        public async Task OnGetAsync()
        {
            AuthorModel = await _context.Authors.ToListAsync();
        }
    }
}
