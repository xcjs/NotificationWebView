using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.Integration;
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
				ElementHost.EnableModelessKeyboardInterop(chromiumForm);
				ShowWebView();
			}
			else if(!chromiumForm.IsVisible)
			{
				ShowWebView();
			}
			else
			{
				chromiumForm.Hide();
			}
		}

		private void ShowWebView()
		{
			if (chromiumForm == null) return;

			var dpiSettings = new DpiCalculator();
			dpiSettings.LoadDpi();

			chromiumForm.Left = Cursor.Position.X / dpiSettings.ScalingFactorX - chromiumForm.Width / 2;

			// The WPF form height is already adjusted for the DPI - WorkingArea.Bottom will report the physical pixels.
			chromiumForm.Top = Screen.PrimaryScreen.WorkingArea.Bottom / dpiSettings.ScalingFactorY - chromiumForm.Height;

			chromiumForm.Show();
		}
	}
}
