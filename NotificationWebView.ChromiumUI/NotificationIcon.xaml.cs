using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace NotificationWebView.ChromiumUI
{
	/// <summary>
	/// Interaction logic for NotificationIcon.xaml
	/// </summary>
	public partial class NotificationIcon : ResourceDictionary
	{
		public MainWindow Browser { get; set; }

		public NotificationIcon()
		{
			Browser = new MainWindow();
		}

		public void ToggleBrowser()
		{
			if(!Browser.IsVisible)
			{
				Browser.SlideUp();
			}
			else
			{
				Browser.SlideDown();
			}
		}

		private void NotificationWebViewIcon_TrayLeftMouseDown(object sender, RoutedEventArgs e)
		{
			ToggleBrowser();
		}

		private void MenuItem_MouseLeftButtonUp(object sender, RoutedEventArgs e)
		{
			App.Current.Shutdown();
		}	
	}
}
