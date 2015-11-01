using System.Drawing;

namespace NotificationWebView.ChromiumUI
{
	class DpiCalculator
	{
		public float DpiX { get; set; }
		public float DpiY { get; set; }
		public float ScalingFactorX { get; set; }
		public float ScalingFactorY { get; set; }

		public const int DefaultDpi = 96;

		private Image pokeBitmap;

		

		public DpiCalculator()
		{
			pokeBitmap = new Bitmap(1, 1);
		}

		public void LoadDpi()
		{
			var g = Graphics.FromImage(pokeBitmap);

			DpiX = g.DpiX;
			DpiY = g.DpiY;
			ScalingFactorX = DpiX / DefaultDpi;
			ScalingFactorY = DpiY / DefaultDpi;
		}
	}
}
