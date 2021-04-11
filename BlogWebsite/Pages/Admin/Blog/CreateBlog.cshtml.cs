using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BlogWebsite.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BlogWebsite.Pages.Admin.Blog
{
    public class CreateBlogModel : PageModel
    {
        public BlogModel Blog { get; set; } = new BlogModel();

        public AuthorModel BlogAuthor { get; set; } = new AuthorModel();

        [BindProperty(SupportsGet = true)]
        public string AuthorName { get; set; }
        
        
        public List<SelectListItem> AuthorList { get; set; } = new List<SelectListItem>

    {
        new SelectListItem { Value = "A1", Text = "Jayanthi" },
        new SelectListItem { Value = "A2", Text = "Vijayakumar" },
        new SelectListItem { Value = "A3", Text = "Roshini"  },
    };
        public void OnGet()
        {
     
            if (AuthorName != null)
            {
                AuthorList.Add(new SelectListItem { Value = "A4", Text = AuthorName });
            }
            
        }
    }
}
