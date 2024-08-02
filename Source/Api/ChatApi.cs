using LeagueAI.Libraries.Helper;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace LeagueAI.Libraries.Api
{
    public sealed class ChatApi : BaseApiMember<GameApi>
    {
        public ChatApi(GameApi api) : base(api) { }

        public void TalkInGame(string message, int delayPressKey = 40, int delay = 200)
        {
            Thread.Sleep(300);

            InputHelper.PressKey(Keys.Enter, delay);
            InputHelper.InputWords(message, delayPressKey, delay);
            InputHelper.PressKey(Keys.Enter, delay);
        }

        public void TalkInClient(string message, int delayPressKey = 20, int delay = 200)
        {
            Thread.Sleep(1500);

            var locationSafe = DEFINE.ColorBoxChatBanPick;
            var color = Color.FromArgb(locationSafe[0], locationSafe[1], locationSafe[2]);

            var handle = Program.ClientHandle;
            if (handle == null || handle == System.IntPtr.Zero) return;

            Point? target = ScreenHelper.GetColorPosition(color, handle, deviantX: 0, deviantY: 0);
            if (target == null) return;

            InputHelper.LeftClick(target.Value.X, target.Value.Y, delay);
            InputHelper.InputWords(message, delayPressKey, delay);
            InputHelper.PressKey(Keys.Enter, delay);
        }
    }
}
