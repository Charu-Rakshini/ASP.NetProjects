using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ToDoWebsite.Data;
using ToDoWebsite.Models;

namespace ToDoWebsite.Pages.ToDo
{
    [Authorize]
    public class DeleteModel : PageModel
    {
        private readonly ToDoWebsite.Data.ToDoDbContext _context;

        public DeleteModel(ToDoWebsite.Data.ToDoDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ToDoModel ToDoModel { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ToDoModel = await _context.ToDos.FirstOrDefaultAsync(m => m.ToDoModelId == id);

            if (ToDoModel == null)
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

            ToDoModel = await _context.ToDos.FindAsync(id);

            if (ToDoModel != null)
            {
                _context.ToDos.Remove(ToDoModel);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
