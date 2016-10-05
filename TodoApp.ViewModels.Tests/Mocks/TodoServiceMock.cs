using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoApp.Services;

namespace TodoApp.ViewModels.Tests.Mocks
{
    public class TodoServiceMock : ITodoService
    {
        List<TodoItem> _items = new List<TodoItem>();

        public Task<IEnumerable<TodoItem>> GetTodoItems()
        {
            return Task.FromResult(_items.Where(x => !x.Completed).AsEnumerable());
        }

        public Task InsertTodoItem(string todoItemText)
        {
            var item = new TodoItem() { Id = Guid.NewGuid().ToString(), Name = todoItemText };
            _items.Add(item);
            return Task.FromResult<object>(null);
        }

        public Task UpdateTodoItem(TodoItem item)
        {
            var itemToUpdate = _items.Where(x => x.Id == item.Id).FirstOrDefault();
            if (itemToUpdate != null)
            {
                itemToUpdate.Completed = true;
            }

            return Task.FromResult<object>(null);
        }
    }
}
