using System;
using Prism.Navigation;
using TodoApp.Services;

namespace TodoApp.ViewModels
{
    public class MainPageViewModel : TodoViewModel, INavigationAware
    {
        private bool _isLoading;
        public bool IsLoading
        {
            get { return _isLoading; }
            set { SetProperty(ref _isLoading, value); }
        }

        public MainPageViewModel(ITodoService todoService)
            : base(todoService)
        {

        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {
            
        }

        public async void OnNavigatedTo(NavigationParameters parameters)
        {
            IsLoading = true;
            await GetTodoItems();
            IsLoading = false;
        }

        public void OnNavigatingTo(NavigationParameters parameters)
        {
            
        }
    }
}
