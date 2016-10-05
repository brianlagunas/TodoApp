using Microsoft.WindowsAzure.MobileServices;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TodoApp.Services
{
    public class AzureTodoService : ITodoService
    {
        MobileServiceClient _client;
        IMobileServiceTable<TodoItem> _todoTable;

        public AzureTodoService()
        {
            _client = new MobileServiceClient("https://prismservices.azurewebsites.net");
            _todoTable = _client.GetTable<TodoItem>();
        }

        public Task<IEnumerable<TodoItem>> GetTodoItems()
        {
            try
            {
                return _todoTable.Where(todoItem => todoItem.Completed == false).ToEnumerableAsync();
            }
            catch (MobileServiceInvalidOperationException e)
            {
                //handle exception
                return null;
            }
        }

        public Task InsertTodoItem(string todoItemText)
        {
            try
            {
                var item = new TodoItem() { Name = todoItemText };
                return _todoTable.InsertAsync(item);
            }
            catch (MobileServiceInvalidOperationException e)
            {
                //handle exception
                return null;
            }
        }

        public Task UpdateTodoItem(TodoItem item)
        {
            try
            {
                item.Completed = true;
                return _todoTable.UpdateAsync(item);
            }
            catch (MobileServiceInvalidOperationException e)
            {
                //handle exception
                return null;
            }
        }
    }
}
