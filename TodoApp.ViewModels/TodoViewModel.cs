using Prism.Commands;
using Prism.Mvvm;
using TodoApp.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TodoApp.ViewModels
{
    public class TodoViewModel : BindableBase
    {
        ITodoService _todoService;

        private string _todoText;
        public string TodoText
        {
            get { return _todoText; }
            set { SetProperty(ref _todoText, value); }
        }

        private IEnumerable<TodoItem> _items;
        public IEnumerable<TodoItem> Items
        {
            get { return _items; }
            set { SetProperty(ref _items, value); }
            //set { _items = value; } //simulate breaking change
        }

        private bool _isRefreshing;
        public bool IsRefreshing
        {
            get { return _isRefreshing; }
            set { SetProperty(ref _isRefreshing, value); }
        }

        public DelegateCommand AddTodoItemCommand => new DelegateCommand(AddTodoItem, CanAddTodoItem).ObservesProperty(() => TodoText);
        public DelegateCommand<TodoItem> CompleteTodoItemCommand => new DelegateCommand<TodoItem>(CompleteTodoItem);

        public DelegateCommand RefreshCommand => new DelegateCommand(Refresh);

        public TodoViewModel(ITodoService todoService)
        {
            _todoService = todoService;
        }

        private async void AddTodoItem()
        {
            await _todoService.InsertTodoItem(TodoText);
            TodoText = null;
            await GetTodoItems();
        }

        private bool CanAddTodoItem()
        {
            return !string.IsNullOrWhiteSpace(TodoText);
        }

        private async void CompleteTodoItem(TodoItem item)
        {
            await _todoService.UpdateTodoItem(item);
            await GetTodoItems();
        }

        private async void Refresh()
        {
            await GetTodoItems();
        }

        protected async Task GetTodoItems()
        {
            IsRefreshing = true;
            Items = await _todoService.GetTodoItems();
            IsRefreshing = false;
        }
    }
}
