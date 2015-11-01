using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using NotificationWebView.ChromiumUI;

namespace NotificationWebView.NotificationIcon
{
	class NotificationApplicationContext : ApplicationContext
	{
		private IContainer components;		// a list of components to dispose when the context is disposed
		private NotifyIcon notifyIcon;      // the icon that sits in the system tray
		private MainWindow chromiumForm = null;

		public NotificationApplicationContext()
		{
			InitializeContext();
		}

		private void InitializeContext()
		{
			components = new System.ComponentModel.Container();
			notifyIcon = new NotifyIcon(components)
			{
				ContextMenuStrip = new ContextMenuStrip(),
				Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath),
				Text = "TrayWebView",
				Visible = true
			};
			notifyIcon.Click += notifyIcon_Click;
		}

		private void notifyIcon_Click(object sender, EventArgs e)
		{
			if (chromiumForm == null)
			{
				chromiumForm = new MainWindow();
				chromiumForm.SlideUp();
			}
			else if(!chromiumForm.IsVisible)
			{
				chromiumForm.SlideUp();
			}
			else
			{
				chromiumForm.SlideDown();
			}
		}		
	}
}
