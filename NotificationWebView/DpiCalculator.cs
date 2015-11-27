using System;
using System.Drawing;

namespace NotificationWebView
{
	class DpiCalculator: IDisposable
	{
		public float DpiX { get; set; }
		public float DpiY { get; set; }
		public float ScalingFactorX { get; set; }
		public float ScalingFactorY { get; set; }

		public const int DefaultDpi = 96;

		private Image PokeBitmap;	

		public DpiCalculator()
		{
			PokeBitmap = new Bitmap(1, 1);
		}

		public void LoadDpi()
		{
			var g = Graphics.FromImage(PokeBitmap);

			DpiX = g.DpiX;
			DpiY = g.DpiY;
			ScalingFactorX = DpiX / DefaultDpi;
			ScalingFactorY = DpiY / DefaultDpi;
		}

		public void Dispose()
		{
			PokeBitmap.Dispose();
		}
	}
}
