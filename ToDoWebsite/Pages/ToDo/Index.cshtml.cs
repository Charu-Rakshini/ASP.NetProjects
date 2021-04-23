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
    public class IndexModel : PageModel
    {
        private readonly ToDoWebsite.Data.ToDoDbContext _context;

        public IndexModel(ToDoWebsite.Data.ToDoDbContext context)
        {
            _context = context;
        }

        public IList<ToDoModel> ToDoModel { get;set; }

        public async Task OnGetAsync()
        {
            ToDoModel = await _context.ToDos.ToListAsync();
        }
    }
}
