using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ToDoWebsite.Data;
using ToDoWebsite.Models;

namespace ToDoWebsite.Pages.ToDo
{
    public class DetailsModel : PageModel
    {
        private readonly ToDoWebsite.Data.ToDoDbContext _context;

        public DetailsModel(ToDoWebsite.Data.ToDoDbContext context)
        {
            _context = context;
        }

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
    }
}
