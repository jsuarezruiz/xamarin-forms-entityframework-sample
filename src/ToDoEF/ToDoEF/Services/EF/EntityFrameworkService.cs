using System.Collections.Generic;
using System.Linq;
using ToDoEF.Models;

namespace ToDoEF.Services.EF
{
    public class EntityFrameworkService : IEntityFrameworkService
    {
        private DatabaseContext _context;

        public EntityFrameworkService()
        {
            _context = new DatabaseContext();
        }

        public IList<TodoItem> GetAll()
        {
            _context = new DatabaseContext();
            return _context.TodoItems.ToList();
        }

        public void Insert(TodoItem item)
        {
            var todoItem = _context.TodoItems.Find(item.Id);

            if (todoItem == null)
            {
                _context.TodoItems.Add(item);
            }
            else
            {
                todoItem.Id = item.Id;
                todoItem.Name = item.Name;
                todoItem.Notes = item.Notes;
                todoItem.Done = item.Done;

                _context.TodoItems.Update(todoItem);
            }

            _context.SaveChanges();
        }

        public void Remove(TodoItem item)
        {
            _context.TodoItems.Remove(item);
            _context.SaveChanges();
        }
    }
}