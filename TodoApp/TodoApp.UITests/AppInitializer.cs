using System;
using System.IO;
using System.Linq;
using System.Reflection;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace TodoApp.UITests
{
	public class AppInitializer
	{
		public static IApp StartApp(Platform platform)
		{
			if (platform == Platform.Android)
			{
				string currentFile = new Uri(Assembly.GetExecutingAssembly().CodeBase).LocalPath;
				FileInfo fi = new FileInfo(currentFile);
				string dir = fi.Directory.Parent.Parent.Parent.FullName;

				var pathToAPK = Path.Combine(dir, "TodoApp.Droid", "bin", "Release", "TodoApp.Droid-Signed.apk");


				//use "adb devices" command line command to get list of devices attached
				return ConfigureApp.Android.DeviceSerial("emulator-5554").ApkFile(pathToAPK).StartApp();
			}

			return ConfigureApp.iOS.StartApp();
		}
	}
}

