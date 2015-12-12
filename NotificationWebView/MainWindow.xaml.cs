using System;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media.Animation;
using CefSharp.Wpf;
using NotificationWebView.ViewModels;

namespace NotificationWebView
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window, IDisposable
	{
		private Browser _viewModel = null;

		private Storyboard SlideUpStoryboard = null;
		private Storyboard SlideDownStoryboard  = null;

		private DoubleAnimation SlideUpAnimation = null;
		private DoubleAnimation SlideDownAnimation = null;

		private bool AllowFormClose = false;

		public MainWindow()
		{
			InitializeComponent();

			if(Title == null)
			{
				Title = AppDomain.CurrentDomain.FriendlyName;
            }

			_viewModel = DataContext as Browser;

			SlideUpStoryboard = (Storyboard)TryFindResource("SlideUpStoryboard");
			SlideDownStoryboard = (Storyboard)TryFindResource("SlideDownStoryboard");

			SlideUpAnimation = (DoubleAnimation)SlideUpStoryboard.Children.First();
			SlideDownAnimation = (DoubleAnimation)SlideDownStoryboard.Children.First();

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

				SlideUpAnimation.From = Top = Screen.PrimaryScreen.Bounds.Bottom;
				Show();

				Left = cursor.X / dpiSettings.ScalingFactorX - ActualWidth / 2;

				if ((Left + ActualWidth) * dpiSettings.ScalingFactorX > Screen.PrimaryScreen.Bounds.Right)
				{
					Left = Screen.PrimaryScreen.Bounds.Right / dpiSettings.ScalingFactorX - ActualWidth;
				}

				// The WPF form height is already adjusted for the DPI (software pixels) - WorkingArea.Bottom will report the physical pixels.
				SlideUpAnimation.To = Screen.PrimaryScreen.WorkingArea.Bottom / dpiSettings.ScalingFactorY - ActualHeight;
			}

			SlideUpStoryboard.Begin(this);
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

		public void Dispose()
		{
			if (WebView != null)
			{
				WebView.Dispose();
			}

			AllowFormClose = true;
			Close();			
		}

		private void txtAddress_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
		{
			var textBox = (System.Windows.Controls.TextBox)sender;
			textBox.SelectAll();
		}

		private void txtAddress_GotMouseCapture(object sender, System.Windows.Input.MouseEventArgs e)
		{
			var textBox = (System.Windows.Controls.TextBox)sender;
			textBox.SelectAll();
		}
	}
}
