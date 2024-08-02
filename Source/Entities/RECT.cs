using System.Runtime.InteropServices;

namespace LeagueAI.Libraries.Entities
{

    [StructLayout(LayoutKind.Sequential)]
    public struct RECT
    {
        public int Left;        // x position of upper-left corner
        public int Top;         // y position of upper-left corner
        public int Right;       // x position of lower-right corner
        public int Bottom;      // y position of lower-right corner

        public override string ToString()
        {
            return string.Format("Left: {0} Top: {1} Right: {2} Bottom: {3}", Left, Top, Right, Bottom);
        }
    }
}
