using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ToDoWebsite.Data;
using ToDoWebsite.Models;

namespace ToDoWebsite.Pages.ToDo
{
    [Authorize]
    public class EditModel : PageModel
    {
        private readonly ToDoWebsite.Data.ToDoDbContext _context;

        public EditModel(ToDoWebsite.Data.ToDoDbContext context)
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

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(ToDoModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ToDoModelExists(ToDoModel.ToDoModelId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ToDoModelExists(int id)
        {
            return _context.ToDos.Any(e => e.ToDoModelId == id);
        }
    }
}
