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
	public partial class MainWindow : Window, IDisposable
	{
		private Storyboard SlideUpStoryboard = null;
		private Storyboard SlideDownStoryboard  = null;

		private DoubleAnimation SlideUpAnimation = null;
		private DoubleAnimation SlideDownAnimation = null;

		private ChromiumWebBrowser Browser = null;
		private CefSettings WebViewSettings = null;

		private bool AllowFormClose = false;

		public MainWindow()
		{
			WebViewSettings = new CefSettings();
			WebViewSettings.UserAgent = String.Format("Mozilla/5.0 (Linux; 6.0;) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/{0} Mobile Safari/537.36", Cef.ChromiumVersion);

			Cef.Initialize(WebViewSettings);

			InitializeComponent();		

			SlideUpStoryboard = (Storyboard)TryFindResource("SlideUpStoryboard");
			SlideDownStoryboard = (Storyboard)TryFindResource("SlideDownStoryboard");

			SlideUpAnimation = (DoubleAnimation)SlideUpStoryboard.Children.First();
			SlideDownAnimation = (DoubleAnimation)SlideDownStoryboard.Children.First();

			Loaded += new RoutedEventHandler(delegate (object sender, RoutedEventArgs e)
			{
				NavigateTo("https://www.google.com");
			});

			Closing += new CancelEventHandler(delegate (object sender, CancelEventArgs e)
			{
				if(!AllowFormClose)
				{
					e.Cancel = true;
				}				
				SlideDown();		
			});

			System.Windows.Application.Current.Exit += Current_Exit;

			SlideDownAnimation.Completed += new EventHandler(delegate (object o, EventArgs e)
			{
				Hide();
			});
		}

		private void Current_Exit(object sender, ExitEventArgs e)
		{
			Dispose();
		}

		public void SlideUp()
		{
			using (var dpiSettings = new DpiCalculator())
			{
				dpiSettings.LoadDpi();

				System.Drawing.Point cursor = Control.MousePosition;

				SlideUpAnimation.From = Screen.PrimaryScreen.Bounds.Bottom;
				Top = SlideUpAnimation.From.Value;				

				Left = cursor.X / dpiSettings.ScalingFactorX - ActualWidth / 2;

				Show();

				// The WPF form height is already adjusted for the DPI (software pixels) - WorkingArea.Bottom will report the physical pixels.
				SlideUpAnimation.To = Screen.PrimaryScreen.WorkingArea.Bottom / dpiSettings.ScalingFactorY - ActualHeight;

				SlideUpStoryboard.Begin(this);
			}		
		}

		public void SlideDown()
		{
			if (!IsVisible) return;

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

			Browser = new ChromiumWebBrowser()
			{
				Address = url
			};

			txtUrl.Text = Browser.Address;

			WebView.Content = Browser;

			WebView.MouseDown += new MouseButtonEventHandler(delegate (object sender, MouseButtonEventArgs e)
			{
				Browser.Focus();
			});
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

		public void Dispose()
		{
			if (Browser == null) return;

			AllowFormClose = true;
			Close();
			Browser.Dispose();
		}
	}
}
