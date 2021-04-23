using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Microsoft.VisualBasic;
using ToDoWebsite.Data;

namespace ToDoWebsite.Pages
{
    public class IndexModel : PageModel
    {


        private readonly ILogger<IndexModel> _logger;
        private readonly ToDoDbContext _context;

        public IndexModel(ILogger<IndexModel> logger, ToDoDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        [BindProperty]
        public Models.ToDoModel ToDo { get; set; }

        //public ICollection<Models.ToDoModel> Temp;
        public ICollection<Models.ToDoModel> Done;
        public ICollection<Models.ToDoModel> Next;

        //ICollection<Models.ToDoModel> Done = new ICollection<Models.ToDoModel>();
        //List<Models.ToDoModel> Next = new List<Models.ToDoModel>();


        public void OnGet()
        {
            //Temp = _context.ToDos.Where(todo => todo.DueDate < DateTime.Now).ToList();
            TimeSpan hoursOfDay = new TimeSpan(24, 0, 0);
            //var timeSinceOrder = DateTime.Now - Temp.FirstOrDefault<DueDate>;

            //if (timeSinceOrder < TimeSpan.FromHours(24))
            //{
            //Done = _context.ToDos.Where(todo => TimeSpan.Compare(DateTime.Now.Hour,todo.DueDate.TimeOfDay.Hours) < TimeSpan.FromHours(24)).ToList();
            Done = _context.ToDos.Where(todo => todo.DoneDate == DateTime.Now.Date).ToList();
            //}



            Next = _context.ToDos.Where(todo => todo.DueDate == DateTime.Now.Date.AddDays(1)).ToList();
        }
    }
}
