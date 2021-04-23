using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ToDoWebsite.Data;
using ToDoWebsite.Models;

namespace ToDoWebsite.Pages.ToDo
{
    [Authorize]
    public class CreateModel : PageModel
    {
        private readonly ToDoWebsite.Data.ToDoDbContext _context;

        public CreateModel(ToDoWebsite.Data.ToDoDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            this.ToDoModel = new Models.ToDoModel();
            this.ToDoModel.UserEmail = User.Identity.Name;
            return Page();
        }

        [BindProperty]
        public Models.ToDoModel ToDoModel { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.ToDos.Add(ToDoModel);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
