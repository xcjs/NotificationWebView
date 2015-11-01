using System;
using System.Windows.Forms;

namespace NotificationWebView.NotificationIcon
{
	static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);

			var trayContext = new NotificationApplicationContext();
			Application.Run(trayContext);
		}
	}
}
