using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TodoApp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CrashPage : ContentPage
	{
		public String ExceptionMessage { get; } = String.Empty;

		public CrashPage()
		{
			InitializeComponent();
			this.BindingContext = this;
		}

		public CrashPage(String exceptionMessage)
		{
			InitializeComponent();
			BindingContext = this;
			ExceptionMessage = exceptionMessage;
		}
	}
}