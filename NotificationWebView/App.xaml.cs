using System;
using System.Windows;
using CefSharp;
using Hardcodet.Wpf.TaskbarNotification;
using NotificationWebView.Services;

namespace NotificationWebView
{
	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class App : System.Windows.Application
	{
		private TaskbarIcon _notificationIcon;
		private CefSettings _webViewSettings = null;

		public App()
		{
			_webViewSettings = new CefSettings();
			_webViewSettings.UserAgent = string.Format(
				"Mozilla/5.0 (Linux; 6.0; Android 6.0.1;) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/{0} Mobile Safari/537.36", Cef.ChromiumVersion);

			Cef.Initialize(_webViewSettings);
		}

		protected override void OnStartup(StartupEventArgs e)
		{
			base.OnStartup(e);
			ShutdownMode = ShutdownMode.OnExplicitShutdown;

			_notificationIcon = (TaskbarIcon)FindResource("NotificationWebViewIcon");			
		}

		protected override void OnExit(ExitEventArgs e)
		{
			base.OnExit(e);
			_notificationIcon.Dispose();
			SubProcessService.KillSubProcesses();
		}
	}
}
