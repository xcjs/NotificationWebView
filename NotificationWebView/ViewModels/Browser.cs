using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using CefSharp;
using CefSharp.Wpf;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace NotificationWebView.ViewModels
{
	public class Browser: ViewModelBase
	{
		private string _addressInput;
		public string AddressInput
		{
			get
			{
				return _addressInput;
			}
			set
			{
				Set(ref _addressInput, value);
			}
		}

		private string _address;
		public string Address
		{
			get
			{
				return _address;
			}
			set
			{
				Set(ref _address, value);
			}
		}

		private string _title;
		public string Title
		{
			get
			{
				return _title;
			}
			set
			{
				Set(ref _title, value);
			}
		}

		private IWpfWebBrowser _webView;
		public IWpfWebBrowser WebView
		{
			get {
				return _webView;
			}
			set
			{
				Set(ref _webView, value);
			}
		}

		public ICommand GoCommand { get; private set; }

		private const string HOME_PAGE = "https://www.google.com/";

		public Browser()
		{
			PropertyChanged += OnPropertyChanged;
			AddressInput = HOME_PAGE;
			Go();
			GoCommand = new RelayCommand(Go, () => !string.IsNullOrWhiteSpace(Address));
		}

		private void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			switch (e.PropertyName)
			{
				case nameof(Address):
					AddressInput = Address;
					break;
				case nameof(WebView):
					AssignEvents();
					break;
			}
		}

		private void AssignEvents()
		{
			if(WebView == null) return;

			WebView.FrameLoadEnd += delegate
			{
				Application.Current.Dispatcher.BeginInvoke((Action)(() => WebView.Focus()));
			};
		}

		private void Go()
		{
			Address = AddressInput;
			Keyboard.ClearFocus();
		}
	}
}
