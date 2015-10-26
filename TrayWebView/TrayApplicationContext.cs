using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.Integration;
using TrayWebView.ChromiumUI;

namespace TrayWebView.TrayIcon
{
	class TrayApplicationContext : ApplicationContext
	{
		private IContainer components;		// a list of components to dispose when the context is disposed
		private NotifyIcon notifyIcon;      // the icon that sits in the system tray
		private MainWindow chromiumForm = null;

		public TrayApplicationContext()
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
				ElementHost.EnableModelessKeyboardInterop(chromiumForm);
				chromiumForm.Show();

			}
			else
			{
				chromiumForm.Activate();
			}
		}
	}
}
