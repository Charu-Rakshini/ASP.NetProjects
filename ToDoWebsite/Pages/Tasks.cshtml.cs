using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ToDoWebsite.Data;


namespace ToDoWebsite.Pages
{
    public class TasksModel : PageModel
    {
        private readonly ToDoDbContext _context;

        public TasksModel(ToDoDbContext context)
        {
            _context = context;
        }

        public ICollection<Models.ToDoModel> TaskList;

        public void OnPost(int? ToDoModelId)
        {
            Models.ToDoModel task = _context.ToDos.FirstOrDefault(t => t.ToDoModelId == ToDoModelId);
            task.Done = true;
            _context.Update(task);
            _context.SaveChanges();
            Redirect("/index");
        }
        public void OnGet()
        {
            TaskList = _context.ToDos.ToList();
        }
    }
}
