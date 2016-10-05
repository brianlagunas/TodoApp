using Prism.Regions;
using TodoApp.Services;
using TodoApp.ViewModels;

namespace TodoApp.Modules.Todo.ViewModels
{
    public class TodoFormViewModel : TodoViewModel, INavigationAware
    {
        public TodoFormViewModel(ITodoService todoService)
            : base (todoService)
        {

        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
            
        }

        public async void OnNavigatedTo(NavigationContext navigationContext)
        {
            await GetTodoItems();
        }
    }
}
