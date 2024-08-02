using InputManager;
using LeagueAI.Libraries.Helper;
using System.Drawing;
using System.Threading;

namespace LeagueAI.Libraries.Api
{
    public sealed class CameraApi : BaseApiMember<GameApi>
    {
        public bool isLocked { get; set; }
        public CameraApi(GameApi api) : base(api)
        {
            isLocked = false;
        }

        public void Toggle()
        {
            // Khoá/mở camera
            string key = Configuration.Instance.SettingGame?.hotKeys?.evtCameraLockToggle?.ToString() ?? "y";
            key = key?.Replace("[", "")?.Replace("]", "")?.ToUpper();
            InputHelper.PressKey(key, 50);
            isLocked = !isLocked;
        }

        public void LockAlly(
            int allyIndice
            )
        {
            // Khoá camera vào đồng minh
            string key = "F" + allyIndice;
            InputHelper.KeyUp(key, 50);
            InputHelper.KeyDown(key, 50);
            Thread.Sleep(BotApi.IDLE_DELAY);
        }

        public void PingComing()
        {
            // Ping đang tới
            var startPoint = new Point(DEFINE.TargetClick[0], DEFINE.TargetClick[1]);
            var endPoint = new Point(DEFINE.TargetClick[0] + 100, DEFINE.TargetClick[1]);

            Mouse.Move(startPoint.X, startPoint.Y);
            InputHelper.PressKey("V", 100);
            Mouse.ButtonDown(Mouse.MouseKeys.Left);
            Thread.Sleep(200);
            Mouse.Move(endPoint.X, endPoint.Y);
            Thread.Sleep(100);
            Mouse.ButtonUp(Mouse.MouseKeys.Left);
            Thread.Sleep(BotApi.IDLE_DELAY);
        }
    }
}
