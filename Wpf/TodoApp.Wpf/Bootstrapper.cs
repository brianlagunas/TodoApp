using Microsoft.Practices.Unity;
using Prism.Unity;
using TodoApp.Wpf.Views;
using System.Windows;
using Prism.Modularity;

namespace TodoApp.Wpf
{
    class Bootstrapper : UnityBootstrapper
    {
        protected override DependencyObject CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void InitializeShell()
        {
            Application.Current.MainWindow.Show();
        }

        protected override IModuleCatalog CreateModuleCatalog()
        {
            return new ConfigurationModuleCatalog();
        }
    }
}
