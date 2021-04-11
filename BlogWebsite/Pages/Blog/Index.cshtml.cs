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
    public class IndexModel : PageModel
    {
        private readonly BlogWebsite.Context.DataContext _context;

        public IndexModel(BlogWebsite.Context.DataContext context)
        {
            _context = context;
        }

        public IList<BlogModel> BlogModel { get;set; }

        public async Task OnGetAsync()
        {
            BlogModel = await _context.Blogs.ToListAsync();
        }
    }
}
