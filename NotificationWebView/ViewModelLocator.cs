using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;
using NotificationWebView.ViewModels;

namespace NotificationWebView
{
	public class ViewModelLocator
	{
		public Browser Browser => ServiceLocator.Current.GetInstance<Browser>();

		public ViewModelLocator()
		{
			ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
			SimpleIoc.Default.Register<Browser>();
		}		
	}
}
