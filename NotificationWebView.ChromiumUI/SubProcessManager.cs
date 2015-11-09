using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationWebView.ChromiumUI
{
	class SubProcessManager
	{
		private const string SubProcessName = "CefSharp.BrowserSubProcess";

		public static void KillSubProcesses()
		{
			foreach (Process p in Process.GetProcessesByName(SubProcessName))
			{
				try
				{
					p.Kill();
					p.WaitForExit();
				}
				catch (Exception ex)
				{
					
				}
			}
		}
	}
}
