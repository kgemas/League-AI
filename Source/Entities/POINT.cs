using System.Drawing;
using System.Runtime.InteropServices;

namespace LeagueAI.Libraries.Entities
{
    [StructLayout(LayoutKind.Sequential)]
    public struct POINT
    {
        public int X;
        public int Y;

        public static implicit operator Point(POINT point)
        {
            return new Point(point.X, point.Y);
        }
    }
}
