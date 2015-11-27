using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Hardcodet.Wpf.TaskbarNotification;
using NotificationWebView.Services;

namespace NotificationWebView
{
	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class NotificationApp : System.Windows.Application
	{
		private TaskbarIcon notificationIcon;

		protected override void OnStartup(StartupEventArgs e)
		{
			base.OnStartup(e);
			ShutdownMode = ShutdownMode.OnExplicitShutdown;

			notificationIcon = (TaskbarIcon)FindResource("NotificationWebViewIcon");
		}

		protected override void OnExit(ExitEventArgs e)
		{
			base.OnExit(e);
			notificationIcon.Dispose();
			SubProcessService.KillSubProcesses();
		}
	}
}
