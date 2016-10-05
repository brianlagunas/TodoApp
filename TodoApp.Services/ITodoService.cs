using System.Collections.Generic;
using System.Threading.Tasks;

namespace TodoApp.Services
{
    public interface ITodoService
    {
        Task<IEnumerable<TodoItem>> GetTodoItems();

        Task InsertTodoItem(string todoItemText);

        Task UpdateTodoItem(TodoItem item);
    }
}
