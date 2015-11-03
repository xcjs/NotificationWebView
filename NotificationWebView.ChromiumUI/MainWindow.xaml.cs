using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Forms;
using System.Windows.Media.Animation;
using System.Linq;
using System.ComponentModel;
using CefSharp.Wpf;
using System.Threading.Tasks;

namespace NotificationWebView.ChromiumUI
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		private Storyboard SlideUpStoryboard = null;
		private Storyboard SlideDownStoryboard  = null;

		private DoubleAnimation SlideUpAnimation = null;
		private DoubleAnimation SlideDownAnimation = null;

		public MainWindow()
		{
			InitializeComponent();

			SlideUpStoryboard = (Storyboard)TryFindResource("SlideUpStoryboard");
			SlideDownStoryboard = (Storyboard)TryFindResource("SlideDownStoryboard");

			SlideUpAnimation = (DoubleAnimation)SlideUpStoryboard.Children.First();
			SlideDownAnimation = (DoubleAnimation)SlideDownStoryboard.Children.First();

			Loaded += new RoutedEventHandler(async delegate (object o, RoutedEventArgs e)
			{
				if (WebView.Content is ChromiumWebBrowser)
				{
					ChromiumWebBrowser oldBrowser = WebView.Content as ChromiumWebBrowser;
					WebView.Content = null;
					oldBrowser.Dispose();
				}
				await Task.Delay(10);

				ChromiumWebBrowser browser = new ChromiumWebBrowser()
				{
					Address = "http://www.xcjs.com"
				};
				WebView.Content = browser;
			});

			Closing += new CancelEventHandler(delegate (object o, CancelEventArgs e)
			{
				e.Cancel = true;
				SlideDown();
			});


			SlideDownAnimation.Completed += new EventHandler(delegate (object o, EventArgs e)
			{
				Hide();
			});
		}

		public void SlideUp()
		{
			var dpiSettings = new DpiCalculator();
			dpiSettings.LoadDpi();

			System.Drawing.Point cursor = Control.MousePosition;

			SlideUpAnimation.From = Screen.PrimaryScreen.Bounds.Bottom;
			Left = cursor.X / dpiSettings.ScalingFactorX - Width / 2;

			// The WPF form height is already adjusted for the DPI - WorkingArea.Bottom will report the physical pixels.
			Top = Screen.PrimaryScreen.WorkingArea.Bottom / dpiSettings.ScalingFactorY - Height;
			SlideUpAnimation.To = Screen.PrimaryScreen.WorkingArea.Bottom / dpiSettings.ScalingFactorY - Height;

			SlideUpStoryboard.Begin(this);
			Show();
		}

		public void SlideDown()
		{
			var dpiSettings = new DpiCalculator();
			dpiSettings.LoadDpi();

			SlideDownAnimation.From = Top;
			SlideDownAnimation.To = Screen.PrimaryScreen.Bounds.Bottom;

			SlideDownStoryboard.Begin(this);
		}
	}
}
