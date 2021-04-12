using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogWebsite.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace BlogWebsite.Pages
{
    
    public class BlogPostModel : PageModel
    {
        public int idArgument;
        public Models.BlogModel Blog;
        private readonly ILogger<BlogPostModel> _logger;
        private readonly BlogWebsite.Context.DataContext _context;

        public BlogPostModel(ILogger<BlogPostModel> logger, DataContext context)
        {
            _logger = logger;
            _context = context;

        }

        public void OnGet(int? id)
        {
            if (id != null)
            {
                //idArgument = id;
                Blog = _context.Blogs.Where(p => p.BlogModelId == id).FirstOrDefault();
            }
            
        }
        
    }
}
