using System.Collections.Generic;
using ToDoEF.Models;

namespace ToDoEF.Services.EF
{
    public interface IEntityFrameworkService
    {
        IList<TodoItem> GetAll();
        void Insert(TodoItem item);
        void Remove(TodoItem item);
    }
}