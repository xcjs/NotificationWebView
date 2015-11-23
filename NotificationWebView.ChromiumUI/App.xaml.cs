using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Hardcodet.Wpf.TaskbarNotification;

namespace NotificationWebView.ChromiumUI
{
	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class App : Application
	{
		private TaskbarIcon notificationIcon;

		protected override void OnStartup(StartupEventArgs e)
		{
			base.OnStartup(e);

			notificationIcon = (TaskbarIcon)FindResource("NotificationWebViewIcon");
		}

		protected override void OnExit(ExitEventArgs e)
		{
			notificationIcon.Dispose();

			base.OnExit(e);
		}
	}
}
