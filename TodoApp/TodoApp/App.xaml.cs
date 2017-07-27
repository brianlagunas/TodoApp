using Prism.Unity;
using TodoApp.Views;
using Microsoft.Practices.Unity;
using TodoApp.Services;
using Microsoft.Azure.Mobile;
using Microsoft.Azure.Mobile.Analytics;
using Microsoft.Azure.Mobile.Crashes;

namespace TodoApp
{
    public partial class App : PrismApplication
    {
        public App(IPlatformInitializer initializer = null) : base(initializer) { }

        protected override void OnInitialized()
        {
            InitializeComponent();

            NavigationService.NavigateAsync("MainPage");
        }

        protected override void RegisterTypes()
        {
            Container.RegisterTypeForNavigation<MainPage>();
            Container.RegisterType<ITodoService, AzureTodoService>(new ContainerControlledLifetimeManager());
        }

		protected override void OnStart()
		{
			MobileCenter.Start("android=3b9c02cc-178f-46f4-a5a9-a93958d6e06a;", typeof(Analytics), typeof(Crashes));
		}
	}
}
