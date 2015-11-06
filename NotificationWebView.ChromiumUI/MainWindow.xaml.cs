using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Forms;
using System.Windows.Media.Animation;
using System.Linq;
using System.ComponentModel;
using CefSharp;
using CefSharp.Wpf;
using System.Threading.Tasks;
using System.Diagnostics;

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

		private CefSettings WebViewSettings = null;

		public MainWindow()
		{
			InitializeComponent();

			WebViewSettings = new CefSettings();
			WebViewSettings.UserAgent = "Mozilla/5.0 (Linux; 6.0;) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/43.0.2357.130 Mobile Safari/537.36";

			Cef.Initialize(WebViewSettings);

			SlideUpStoryboard = (Storyboard)TryFindResource("SlideUpStoryboard");
			SlideDownStoryboard = (Storyboard)TryFindResource("SlideDownStoryboard");

			SlideUpAnimation = (DoubleAnimation)SlideUpStoryboard.Children.First();
			SlideDownAnimation = (DoubleAnimation)SlideDownStoryboard.Children.First();

			Loaded += new RoutedEventHandler(delegate (object o, RoutedEventArgs e)
			{
				NavigateTo("http://xcjs.com");
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
			Top = SlideUpAnimation.From.Value;
			Show();

			Left = cursor.X / dpiSettings.ScalingFactorX - ActualWidth / 2;

			// The WPF form height is already adjusted for the DPI (software pixels) - WorkingArea.Bottom will report the physical pixels.
			SlideUpAnimation.To = Screen.PrimaryScreen.WorkingArea.Bottom / dpiSettings.ScalingFactorY - ActualHeight;

			SlideUpStoryboard.Begin(this);
		}

		public void SlideDown()
		{
			var dpiSettings = new DpiCalculator();
			dpiSettings.LoadDpi();

			SlideDownAnimation.From = Top;
			SlideDownAnimation.To = Screen.PrimaryScreen.Bounds.Bottom;

			SlideDownStoryboard.Begin(this);
		}

		public async void NavigateTo(string url)
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
                Address = url
			};

			txtUrl.Text = browser.Address;

			WebView.Content = browser;
		}

		public void txtUrl_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
		{
			switch (e.Key)
			{
				case Key.Enter:
					NavigateTo(txtUrl.Text);
					break;
			}
		}
	}
}
