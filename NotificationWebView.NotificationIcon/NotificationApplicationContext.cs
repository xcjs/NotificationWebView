using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.Integration;
using NotificationWebView.ChromiumUI;

namespace NotificationWebView.NotificationIcon
{
	class NotificationApplicationContext : ApplicationContext
	{
		private IContainer Components;		// a list of components to dispose when the context is disposed
		private NotifyIcon NotifyIcon;      // the icon that sits in the system tray
		private MainWindow ChromiumForm = null;
		private ContextMenu RightClickMenu = null;

		public NotificationApplicationContext()
		{
			InitializeContext();
		}

		private void InitializeContext()
		{
			Components = new Container();

			RightClickMenu = new ContextMenu();

			var exitMenuItem = new MenuItem();
			exitMenuItem.Text = "Exit NotificationWebView";

			NotifyIcon = new NotifyIcon(Components)
			{
				ContextMenuStrip = new ContextMenuStrip(),
				ContextMenu = new ContextMenu(),
				Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath),
				Text = "NotificationWebView",
				Visible = true
			};

			exitMenuItem.Click += ExitMenuItem_Click;
			NotifyIcon.ContextMenu.MenuItems.Add(exitMenuItem);

			NotifyIcon.Click += notifyIcon_Click;

			if(System.Windows.Application.Current == null)
			{
				new System.Windows.Application();
			}
		}

		private void ExitMenuItem_Click(object sender, EventArgs e)
		{
			CloseWebView();
		}

		private void notifyIcon_Click(object sender, EventArgs e)
		{
			var mouseEvent = e as MouseEventArgs;

			if (mouseEvent == null) return;
			
			switch(mouseEvent.Button)
			{
				default:
					ManageWebViewInstance();
					break;

				case MouseButtons.Right:
					// Do nothing, allow the WinForm to handle the ContextMenu.
					break;
			}		
		}
		
		private void ManageWebViewInstance()
		{
			if (ChromiumForm == null)
			{
				ChromiumForm = new MainWindow();
				ElementHost.EnableModelessKeyboardInterop(ChromiumForm);
				ChromiumForm.SlideUp();
			}
			else if (!ChromiumForm.IsVisible)
			{
				ChromiumForm.SlideUp();
			}
			else
			{
				ChromiumForm.SlideDown();
			}
		}		

		private void CloseWebView()
		{
			if(ChromiumForm != null)
			{
				ChromiumForm.Close();
				ChromiumForm.Dispose();
			}
			
			Application.Exit();
		}
	}
}
