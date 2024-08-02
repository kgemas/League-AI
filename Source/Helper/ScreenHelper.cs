using LeagueAI.Libraries.Entities;
using System;
using System.Drawing;

namespace LeagueAI.Libraries.Helper
{
    public sealed class ScreenHelper
    {
        public static Point? GetColorPosition(
            Color color,
            IntPtr handle,
            int deviantX = 10,
            int deviantY = 10)
        {
            Point? result = null;
            try
            {
                FindColorPosition(
                color,
                handle,
                (point) =>
                {
                    result = point;
                },
                deviantX: deviantX,
                deviantY: deviantY,
                existWhenFound: true
            );
            }
            catch (Exception) { }
            return result;
        }

        public static void FindColorPosition(
            Color color,
            IntPtr handle,
            Action<Point> whenFound = null,
            int deviantX = 10,
            int deviantY = 10,
            bool existWhenFound = true
            )
        {
            if (handle == null || handle == IntPtr.Zero ||
                !User32.GetWindowRect(handle, out RECT rect)) return;

            var bounds = new Rectangle(rect.Left, rect.Top, rect.Right - rect.Left, rect.Bottom - rect.Top);
            if (bounds.IsEmpty || bounds.Width <= 0 || bounds.Height <= 0) return;

            var bitmap = new Bitmap(rect.Right - rect.Left, rect.Bottom - rect.Top);
            using (Graphics graphics = Graphics.FromImage(bitmap))
            {
                graphics.CopyFromScreen(new Point(bounds.Left, bounds.Top), Point.Empty, bounds.Size);

                for (int x = bitmap.Width - 1; x >= 0; x--)
                {
                    for (int y = bitmap.Height - 1; y >= 0; y--)
                    {
                        Color pixelColor = bitmap.GetPixel(x, y);

                        if (pixelColor.R == color.R && pixelColor.G == color.G && pixelColor.B == color.B)
                        {
                            var result = new Point(x + rect.Left + deviantX, y + rect.Top + deviantY);
                            if (existWhenFound)
                            {
                                whenFound(result);
                                graphics.Dispose();
                                return;
                            }
                            whenFound(result);
                        }
                    }
                }
                graphics.Dispose();
            }
        }
    }
}
