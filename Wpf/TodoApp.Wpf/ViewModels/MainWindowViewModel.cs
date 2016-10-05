using Prism.Mvvm;

namespace TodoApp.Wpf.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private string _title = "Azure Todo";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public MainWindowViewModel()
        {

        }
    }
}
