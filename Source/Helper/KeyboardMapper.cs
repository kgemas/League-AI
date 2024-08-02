using System.Collections.Generic;
using System.Windows.Forms;

namespace LeagueAI.Libraries.Helper
{
    public sealed class KeyboardMapper
    {
        private static readonly Dictionary<char, Keys[]> keyMap = new Dictionary<char, Keys[]>()
        {
            { 'a', new Keys[] { Keys.A } }, { 'A', new Keys[] { Keys.RShiftKey, Keys.A } },
            { 'b', new Keys[] { Keys.B } }, { 'B', new Keys[] { Keys.RShiftKey, Keys.B } },
            { 'c', new Keys[] { Keys.C } }, { 'C', new Keys[] { Keys.RShiftKey, Keys.C } },
            { 'd', new Keys[] { Keys.D } }, { 'D', new Keys[] { Keys.RShiftKey, Keys.D } },
            { 'e', new Keys[] { Keys.E } }, { 'E', new Keys[] { Keys.RShiftKey, Keys.E } },
            { 'f', new Keys[] { Keys.F } }, { 'F', new Keys[] { Keys.RShiftKey, Keys.F } },
            { 'g', new Keys[] { Keys.G } }, { 'G', new Keys[] { Keys.RShiftKey, Keys.G } },
            { 'h', new Keys[] { Keys.H } }, { 'H', new Keys[] { Keys.RShiftKey, Keys.H } },
            { 'i', new Keys[] { Keys.I } }, { 'I', new Keys[] { Keys.RShiftKey, Keys.I } },
            { 'j', new Keys[] { Keys.J } }, { 'J', new Keys[] { Keys.RShiftKey, Keys.J } },
            { 'k', new Keys[] { Keys.K } }, { 'K', new Keys[] { Keys.RShiftKey, Keys.K } },
            { 'l', new Keys[] { Keys.L } }, { 'L', new Keys[] { Keys.RShiftKey, Keys.L } },
            { 'm', new Keys[] { Keys.M } }, { 'M', new Keys[] { Keys.RShiftKey, Keys.M } },
            { 'n', new Keys[] { Keys.N } }, { 'N', new Keys[] { Keys.RShiftKey, Keys.N } },
            { 'o', new Keys[] { Keys.O } }, { 'O', new Keys[] { Keys.RShiftKey, Keys.O } },
            { 'p', new Keys[] { Keys.P } }, { 'P', new Keys[] { Keys.RShiftKey, Keys.P } },
            { 'q', new Keys[] { Keys.Q } }, { 'Q', new Keys[] { Keys.RShiftKey, Keys.Q } },
            { 'r', new Keys[] { Keys.R } }, { 'R', new Keys[] { Keys.RShiftKey, Keys.R } },
            { 's', new Keys[] { Keys.S } }, { 'S', new Keys[] { Keys.RShiftKey, Keys.S } },
            { 't', new Keys[] { Keys.T } }, { 'T', new Keys[] { Keys.RShiftKey, Keys.T } },
            { 'u', new Keys[] { Keys.U } }, { 'U', new Keys[] { Keys.RShiftKey, Keys.U } },
            { 'v', new Keys[] { Keys.V } }, { 'V', new Keys[] { Keys.RShiftKey, Keys.V } },
            { 'w', new Keys[] { Keys.W } }, { 'W', new Keys[] { Keys.RShiftKey, Keys.W } },
            { 'x', new Keys[] { Keys.X } }, { 'X', new Keys[] { Keys.RShiftKey, Keys.X } },
            { 'y', new Keys[] { Keys.Y } }, { 'Y', new Keys[] { Keys.RShiftKey, Keys.Y } },
            { 'z', new Keys[] { Keys.Z } }, { 'Z', new Keys[] { Keys.RShiftKey, Keys.Z } },
            { ' ', new Keys[] { Keys.Space } },

            { ',', new Keys[] { Keys.Oemcomma } }, { '<', new Keys[] { Keys.RShiftKey, Keys.Oemcomma } },
            { '.', new Keys[] { Keys.OemPeriod } }, { '>', new Keys[] { Keys.RShiftKey, Keys.OemPeriod } },
            { '/', new Keys[] { Keys.OemQuestion } }, { '?', new Keys[] { Keys.RShiftKey, Keys.OemQuestion } },
            { ';', new Keys[] { Keys.OemSemicolon } }, { ':', new Keys[] { Keys.RShiftKey, Keys.OemSemicolon } },
            { '\'', new Keys[] { Keys.OemQuotes } }, { '"', new Keys[] { Keys.RShiftKey, Keys.OemQuotes } },
            { '[', new Keys[] { Keys.OemOpenBrackets } }, { '{', new Keys[] { Keys.RShiftKey, Keys.OemOpenBrackets } },
            { ']', new Keys[] { Keys.OemCloseBrackets } }, { '}', new Keys[] { Keys.RShiftKey, Keys.OemCloseBrackets } },
            { '\\', new Keys[] { Keys.OemPipe } }, { '|', new Keys[] { Keys.RShiftKey, Keys.OemPipe } },
            { '`', new Keys[] { Keys.Oemtilde } }, { '~', new Keys[] { Keys.RShiftKey, Keys.Oemtilde } },
            { '-', new Keys[] { Keys.OemMinus } }, { '_', new Keys[] { Keys.RShiftKey, Keys.OemMinus } },
            { '+', new Keys[] { Keys.Oemplus } }, { '=', new Keys[] { Keys.RShiftKey, Keys.Oemplus } },

            { '1', new Keys[] { Keys.D1 } }, { '!', new Keys[] { Keys.RShiftKey, Keys.D1 } },
            { '2', new Keys[] { Keys.D2 } }, { '@', new Keys[] { Keys.RShiftKey, Keys.D2 } },
            { '3', new Keys[] { Keys.D3 } }, { '#', new Keys[] { Keys.RShiftKey, Keys.D3 } },
            { '4', new Keys[] { Keys.D4 } }, { '$', new Keys[] { Keys.RShiftKey, Keys.D4 } },
            { '5', new Keys[] { Keys.D5 } }, { '%', new Keys[] { Keys.RShiftKey, Keys.D5 } },
            { '6', new Keys[] { Keys.D6 } }, { '^', new Keys[] { Keys.RShiftKey, Keys.D6 } },
            { '7', new Keys[] { Keys.D7 } }, { '&', new Keys[] { Keys.RShiftKey, Keys.D7 } },
            { '8', new Keys[] { Keys.D8 } }, { '*', new Keys[] { Keys.RShiftKey, Keys.D8 } },
            { '9', new Keys[] { Keys.D9 } }, { '(', new Keys[] { Keys.RShiftKey, Keys.D9 } },
            { '0', new Keys[] { Keys.D0 } }, { ')', new Keys[] { Keys.RShiftKey, Keys.D0 } },
        };

        public static Keys[] GetKey(char key, int delayPress)
        {
            if (keyMap.TryGetValue(key, out Keys[] value))
            {
                return value;
            }

            return default;
        }
    }
}
