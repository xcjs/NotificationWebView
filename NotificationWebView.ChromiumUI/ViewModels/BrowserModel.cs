using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Threading;
using CefSharp;
using CefSharp.Wpf;

namespace NotificationWebView.ChromiumUI.ViewModels
{
	class BrowserModel : IWpfWebBrowser
	{
		public string Address
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		public ICommand BackCommand
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		public bool CanGoBack
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		public bool CanGoForward
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		public bool CanReload
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		public ICommand CleanupCommand
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		public ICommand CopyCommand
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		public ICommand CutCommand
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		public IDialogHandler DialogHandler
		{
			get
			{
				throw new NotImplementedException();
			}

			set
			{
				throw new NotImplementedException();
			}
		}

		public Dispatcher Dispatcher
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		public IDisplayHandler DisplayHandler
		{
			get
			{
				throw new NotImplementedException();
			}

			set
			{
				throw new NotImplementedException();
			}
		}

		public IDownloadHandler DownloadHandler
		{
			get
			{
				throw new NotImplementedException();
			}

			set
			{
				throw new NotImplementedException();
			}
		}

		public IDragHandler DragHandler
		{
			get
			{
				throw new NotImplementedException();
			}

			set
			{
				throw new NotImplementedException();
			}
		}

		public IFocusHandler FocusHandler
		{
			get
			{
				throw new NotImplementedException();
			}

			set
			{
				throw new NotImplementedException();
			}
		}

		public ICommand ForwardCommand
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		public IGeolocationHandler GeolocationHandler
		{
			get
			{
				throw new NotImplementedException();
			}

			set
			{
				throw new NotImplementedException();
			}
		}

		public bool IsBrowserInitialized
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		public bool IsLoading
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		public IJsDialogHandler JsDialogHandler
		{
			get
			{
				throw new NotImplementedException();
			}

			set
			{
				throw new NotImplementedException();
			}
		}

		public IKeyboardHandler KeyboardHandler
		{
			get
			{
				throw new NotImplementedException();
			}

			set
			{
				throw new NotImplementedException();
			}
		}

		public ILifeSpanHandler LifeSpanHandler
		{
			get
			{
				throw new NotImplementedException();
			}

			set
			{
				throw new NotImplementedException();
			}
		}

		public ILoadHandler LoadHandler
		{
			get
			{
				throw new NotImplementedException();
			}

			set
			{
				throw new NotImplementedException();
			}
		}

		public IContextMenuHandler MenuHandler
		{
			get
			{
				throw new NotImplementedException();
			}

			set
			{
				throw new NotImplementedException();
			}
		}

		public ICommand PasteCommand
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		public ICommand PrintCommand
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		public ICommand RedoCommand
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		public ICommand ReloadCommand
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		public IRequestHandler RequestHandler
		{
			get
			{
				throw new NotImplementedException();
			}

			set
			{
				throw new NotImplementedException();
			}
		}

		public IResourceHandlerFactory ResourceHandlerFactory
		{
			get
			{
				throw new NotImplementedException();
			}

			set
			{
				throw new NotImplementedException();
			}
		}

		public ICommand SelectAllCommand
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		public ICommand StopCommand
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		public string Title
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		public string TooltipText
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		public ICommand UndoCommand
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		public ICommand ViewSourceCommand
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		public ICommand ZoomInCommand
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		public double ZoomLevel
		{
			get
			{
				throw new NotImplementedException();
			}

			set
			{
				throw new NotImplementedException();
			}
		}

		public double ZoomLevelIncrement
		{
			get
			{
				throw new NotImplementedException();
			}

			set
			{
				throw new NotImplementedException();
			}
		}

		public ICommand ZoomOutCommand
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		public ICommand ZoomResetCommand
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		public event EventHandler<ConsoleMessageEventArgs> ConsoleMessage;
		public event EventHandler<FrameLoadEndEventArgs> FrameLoadEnd;
		public event EventHandler<FrameLoadStartEventArgs> FrameLoadStart;
		public event EventHandler<LoadErrorEventArgs> LoadError;
		public event EventHandler<LoadingStateChangedEventArgs> LoadingStateChanged;
		public event EventHandler<StatusMessageEventArgs> StatusMessage;

		public void Dispose()
		{
			throw new NotImplementedException();
		}

		public bool Focus()
		{
			throw new NotImplementedException();
		}

		public IBrowser GetBrowser()
		{
			throw new NotImplementedException();
		}

		public void Load(string url)
		{
			throw new NotImplementedException();
		}

		public void RegisterAsyncJsObject(string name, object objectToBind, bool camelCaseJavascriptNames = true)
		{
			throw new NotImplementedException();
		}

		public void RegisterJsObject(string name, object objectToBind, bool camelCaseJavascriptNames = true)
		{
			throw new NotImplementedException();
		}
	}
}
