using System;
using System.Collections.Generic;
using Prism.Windows.Navigation;
using TodoApp.Services;
using TodoApp.ViewModels;

namespace TodoApp.Uwp.ViewModels
{
    public class MainPageViewModel : TodoViewModel, INavigationAware
    {
        public MainPageViewModel(ITodoService todoService)
            : base (todoService)
        {

        }

        public async void OnNavigatedTo(NavigatedToEventArgs e, Dictionary<string, object> viewModelState)
        {
            await GetTodoItems();
        }

        public void OnNavigatingFrom(NavigatingFromEventArgs e, Dictionary<string, object> viewModelState, bool suspending)
        {
            
        }
    }
}
