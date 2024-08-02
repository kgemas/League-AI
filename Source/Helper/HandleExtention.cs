using LeagueAI.Libraries.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LeagueAI.Libraries.Helper
{
    public static class HandleExtention
    {
        public static IntPtr GetGameHandle(this string nameProcess)
        {
            try
            {
                var activeWindows = GetOpenWindows()
                    .FirstOrDefault(m => m.Value?.Contains(DEFINE.GameExecutableName) == true);
                return activeWindows.Key;
            }
            catch (Exception) { }
            return IntPtr.Zero;
        }

        public static IDictionary<IntPtr, string> GetOpenWindows()
        {
            IntPtr shellWindow = User32.GetShellWindow();
            Dictionary<IntPtr, string> windows = new Dictionary<IntPtr, string>();

            User32.EnumWindows(delegate (IntPtr hWnd, int lParam)
            {
                if (hWnd == shellWindow) return true;
                if (!User32.IsWindowVisible(hWnd)) return true;

                int length = User32.GetWindowTextLength(hWnd);
                if (length == 0) return true;

                var builder = new StringBuilder(length);
                User32.GetWindowText(hWnd, builder, length + 1);

                windows[hWnd] = builder.ToString();
                return true;

            }, 0);

            return windows;
        }

        public static Process GetProcess(this IntPtr hwnd)
        {
            User32.GetWindowThreadProcessId(hwnd, out uint pid);
            Process proc = Process.GetProcessById((int)pid);
            return proc;
        }

        public static int BringToFront(this IntPtr hwnd) => User32.SetForegroundWindow(hwnd);
        public static bool CenterScreen(this IntPtr hwnd)
        {
            const int SWP_NOSIZE = 0x0001;
            //const int SWP_NOZORDER = 0x0004;
            const int SWP_SHOWWINDOW = 0x0040;
            const int SWP_NOMOVE = 0x0200;
            if (!User32.GetWindowRect(hwnd, out RECT rct)) return false;
            Rectangle screen = Screen.FromHandle(hwnd).Bounds;
            Point pt = new Point(screen.Left + screen.Width / 2 - (rct.Right - rct.Left) / 2, screen.Top + screen.Height / 2 - (rct.Bottom - rct.Top) / 2);
            return User32.SetWindowPos(hwnd, IntPtr.Zero, pt.X, pt.Y, 0, 0, SWP_NOMOVE | SWP_NOSIZE | SWP_SHOWWINDOW);
        }
    }
}
