using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BlogWebsite.Models;

namespace BlogWebsite.Pages.Admin.Author
{
    public class CreateAuthorModel : PageModel
    {
        [FromForm]
        public AuthorModel Author { get; set; } = new AuthorModel();

        
        [BindProperty(SupportsGet = true)]
        public string AuthorName { get; set; }




        public void OnGet()

        {

        }

        public IActionResult OnPost()
        {

            return RedirectToPage("/Admin/Blog/CreateBlog", new { authorName = Author.Given_Name });

        }

    }
}
