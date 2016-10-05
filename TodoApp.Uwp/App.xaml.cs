using Prism.Unity.Windows;
using System.Threading.Tasks;
using TodoApp.Services;
using Windows.ApplicationModel.Activation;
using Microsoft.Practices.Unity;

namespace TodoApp.Uwp
{
    /// <summary>
    /// Provides application-specific behavior to supplement the default Application class.
    /// </summary>
    sealed partial class App : PrismUnityApplication
    {
        public App()
        {
            InitializeComponent();
        }

        protected override Task OnLaunchApplicationAsync(LaunchActivatedEventArgs args)
        {
            NavigationService.Navigate("Main", null);
            return Task.FromResult<object>(null);
        }

        protected override Task OnInitializeAsync(IActivatedEventArgs args)
        {
            Container.RegisterType<ITodoService, AzureTodoService>(new ContainerControlledLifetimeManager());

            return base.OnInitializeAsync(args);
        }
    }
}
