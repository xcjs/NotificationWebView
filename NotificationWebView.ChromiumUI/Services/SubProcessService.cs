using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationWebView.Services
{
	class SubProcessService
	{
		private const string SUB_PROCESS_NAME = "CefSharp.BrowserSubProcess";

		public static void KillSubProcesses()
		{
			foreach (Process p in Process.GetProcessesByName(SUB_PROCESS_NAME))
			{
				try
				{
					p.Kill();
					p.WaitForExit();
				}
				catch
				{

				}
			}
		}
	}
}
