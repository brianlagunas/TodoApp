using Prism.Unity;
using TodoApp.Views;
using Microsoft.Practices.Unity;
using TodoApp.Services;
using Microsoft.Azure.Mobile;
using Microsoft.Azure.Mobile.Analytics;
using Microsoft.Azure.Mobile.Crashes;
using System;
using System.Threading.Tasks;

namespace TodoApp
{
	public partial class App : PrismApplication
	{
		public App(IPlatformInitializer initializer = null) : base(initializer) { }

		protected async override void OnInitialized()
		{
			InitializeComponent();

			TaskScheduler.UnobservedTaskException += TaskScheduler_UnobservedTaskException;

			try
			{
				await NavigationService.NavigateAsync("MainPage");
			}
			catch (Exception ex)
			{
				ShowCrashPage(ex);
			}
		}

		protected override void RegisterTypes()
		{
			Container.RegisterTypeForNavigation<MainPage>();
			Container.RegisterType<ITodoService, AzureTodoService>(new ContainerControlledLifetimeManager());
		}

		protected override void OnStart()
		{
			MobileCenter.Start("android=41320330-983d-4d55-8020-56fb7bf8c907;", typeof(Analytics), typeof(Crashes));
		}

		void ShowCrashPage(Exception ex = null)
		{
			Xamarin.Forms.Device.BeginInvokeOnMainThread(() => this.MainPage = new CrashPage(ex?.Message));
		}

		void TaskScheduler_UnobservedTaskException(Object sender, UnobservedTaskExceptionEventArgs e)
		{
			if (!e.Observed)
			{
				// prevents the app domain from being torn down
				e.SetObserved();

				// show the crash page
				ShowCrashPage(e.Exception.Flatten().GetBaseException());
			}
		}
	}
}
