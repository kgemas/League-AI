using LeagueAI.Libraries.Entities;
using LeagueAI.Libraries.Enums;
using LeagueAI.Libraries.Game;
using LeagueAI.Libraries.Helper;
using LeagueAI.Libraries.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;

namespace LeagueAI.Libraries.Api
{
    public sealed class GameApi : IApi
    {
        private static readonly Random rand = new Random();
        public ShopApi shop { get; private set; }
        public CameraApi camera { get; private set; }
        public ChatApi chat { get; private set; }
        public ActivePlayerApi player { get; private set; }
        private ESideTeam? side { get; set; }

        public GameApi()
        {
            shop = new ShopApi(this);
            camera = new CameraApi(this);
            chat = new ChatApi(this);
            player = new ActivePlayerApi(this);
        }

        public void WaitGameStart(int timeout = 60)
        {
            while (timeout >= 0)
            {
                if (GameLCU.IsApiReady()
                    && GameLCU.GetGameTime() > 2d
                    && CheckColorExist(DEFINE.ColorSafePlan.ToColorRGB().Value)
                    )
                {
                    return;
                }
                timeout -= 5;
                Thread.Sleep(5000);
            }
        }

        public void SetupHandleGame(
            int timeout = 300
            )
        {
            while (timeout >= 0)
            {
                Program.GameHandle = HandleExtention.GetGameHandle("");
                if (Program.GameHandle != null && Program.GameHandle != IntPtr.Zero) return;

                timeout -= 10;
                Thread.Sleep(10000);
            }
            Logger.WriteLine(DEFINE.CantStartGame, EMessageState.ERROR);
            Program.Exit(1);
        }

        public bool IsGameOpen() => GameLCU.IsGameOpen();

        public bool IsAPIReady() => GameLCU.IsApiReady();

        public void BringGameToFront()
        {
            // Gán tiến trình game lên đầu (focus).
            if (!GameLCU.BringToFont())
            {
                Logger.WriteLine(DEFINE.ErrorBringToFrontLog, EMessageState.WARNING);
            }
        }

        public void CenterGameToScreen()
        {
            // Căn giữa màn hình.
            if (!GameLCU.CenterScreen())
            {
                Logger.WriteLine(DEFINE.ErrorCenterScreenLog, EMessageState.WARNING);
            }
        }

        public List<PlayerList> GetAllies() => GameLCU.GetAllies();

        public int GetAllyIdToFollow()
        {
            // Chọn lấy thằng khoẻ nhất
            const int StartIndex = 2;
            int max = -1;
            int index = StartIndex;
            int i = index;

            List<PlayerList> allies = GameLCU.GetAllies();
            PlayerList followAlly = null;

            if (allies == null || allies.Count <= 0) return -1;

            foreach (PlayerList ally in allies)
            {
                if (i - StartIndex == 4) break;

                if (ally.summonerName == player.GetName()) continue;

                if (ally.scores.kills > max && ally.isDead == false)
                {
                    if (!ally.summonerSpells.summonerSpellOne.displayName.ToString().ToLower().Contains("smite") && // not jungler
                        !ally.summonerSpells.summonerSpellTwo.displayName.ToString().ToLower().Contains("smite"))
                    {
                        max = (int)ally.scores.kills + (int)ally.scores.assists + ally.level.Value;
                        followAlly = ally;
                        index = i;
                    }
                }
                i++;
            }

            Logger.WriteLine(string.Format(DEFINE.FollowLog, $"[{followAlly.summonerName}]"));
            return index;

        }

        public ESideTeam GetSide()
        {
            if (side == null) side = GameLCU.GetPlayerSide();
            return side.Value;
        }

        public void MoveRandomCenter(
            int delay,
            bool isRandom = true
            )
        {
            int x = DEFINE.TargetClick[0];
            int y = DEFINE.TargetClick[1];
            if (isRandom)
            {
                x += rand.Next(-100, 100);
                y += rand.Next(-100, 100);
            }
            InputHelper.RightClick(x, y, delay);
            Thread.Sleep(BotApi.IDLE_DELAY);
        }

        public void MoveToSafePlace(int moveTime = 10000)
        {
            var handle = Program.GameHandle;
            if (handle == null || handle == IntPtr.Zero) return;

            var locationSafe = DEFINE.ColorSafePlan;
            var color = Color.FromArgb(locationSafe[0], locationSafe[1], locationSafe[2]);
            Point? target = ScreenHelper.GetColorPosition(color, handle, deviantX: 0, deviantY: 0);
            if (target == null) return;
            InputHelper.RightClick(target.Value.X, target.Value.Y, 100);
            Thread.Sleep(moveTime);
        }

        public void MoveToBlackJung(int moveTime = 10000)
        {
            var handle = Program.GameHandle;
            if (handle == null || handle == IntPtr.Zero) return;

            Point? target = ScreenHelper.GetColorPosition(DEFINE.ColorBlackJungle.ToColorRGB().Value, handle, deviantX: 0, deviantY: 0);
            if (target == null) return;
            InputHelper.RightClick(target.Value.X, target.Value.Y, 100);
            Thread.Sleep(moveTime);
        }

        public void MoveToPoint(
            Point target,
            int delay,
            bool random = true
            )
        {
            if (random)
            {
                target.X += rand.Next(40, 150);
                target.Y += rand.Next(40, 150);
            }
            InputHelper.RightClick(target.X, target.Y, delay);
            Thread.Sleep(BotApi.IDLE_DELAY);
        }

        public void MoveToAllyCreep(
            int checkEvery = 3000,
            int loopSearch = 20,
            Point? target = null
            )
        {
            var handle = Program.GameHandle;
            if (handle == null || handle == IntPtr.Zero || loopSearch < 0) return;

            InputHelper.PressKey(System.Windows.Forms.Keys.Space, BotApi.IDLE_DELAY);

            if (FoundEnemy()) return;

            Point? allyCreep = ScreenHelper.GetColorPosition(DEFINE.ColorAllyCreep.ToColorRGB().Value, handle, 0, 0);
            if (allyCreep != null)
            {
                InputHelper.RightClick(allyCreep.Value.X, allyCreep.Value.Y, 1000);
                return;
            }

            // tim ally creep tren man hinh
            if (target == null) target = ScreenHelper.GetColorPosition(DEFINE.ColorAllyCreepMiniMap.ToColorRGB().Value, handle, 0, 0);
            if (target == null) return;
            InputHelper.RightClick(target.Value.X, target.Value.Y, BotApi.IDLE_DELAY);
            Thread.Sleep(checkEvery);
            MoveToAllyCreep(checkEvery, --loopSearch, target);
        }

        public void MoveToAlly(bool moveInto = true)
        {
            var handle = Program.GameHandle;
            if (handle == null || handle == IntPtr.Zero) return;

            InputHelper.PressKey(System.Windows.Forms.Keys.Space, BotApi.IDLE_DELAY);
            Point? ally = ScreenHelper.GetColorPosition(DEFINE.ColorAllyLevelBox.ToColorRGB().Value, handle, 0, 0);
            if (ally != null)
            {
                if (moveInto) InputHelper.RightClick(ally.Value.X, ally.Value.Y, 1000);
                return;
            }
            ally = ScreenHelper.GetColorPosition(DEFINE.ColorAllyCreep.ToColorRGB().Value, handle, 0, 0);
            if (ally != null)
            {
                if (moveInto) InputHelper.RightClick(ally.Value.X, ally.Value.Y, 1000);
                return;
            }
        }

        public bool FoundEnemy()
        {
            var handle = Program.GameHandle;
            if (handle == null || handle == IntPtr.Zero) return false;

            InputHelper.PressKey(System.Windows.Forms.Keys.Space, BotApi.IDLE_DELAY);
            Point? ally = ScreenHelper.GetColorPosition(DEFINE.ColorEnemyLevelBox.ToColorRGB().Value, handle, 0, 0);
            if (ally != null) return true;

            ally = ScreenHelper.GetColorPosition(DEFINE.ColorEnemyFocus.ToColorRGB().Value, handle, 0, 0);
            if (ally != null) return true;

            ally = ScreenHelper.GetColorPosition(DEFINE.ColorEnemyCreep.ToColorRGB().Value, handle, 0, 0);
            if (ally != null) return true;

            return false;
        }

        public void CloseWarning(
            int delay = 100
            )
        {
            var handle = Program.GameHandle;
            if (handle == null || handle == IntPtr.Zero) return;

            Point? target = ScreenHelper.GetColorPosition(DEFINE.ColorWarningAfk.ToColorRGB().Value, handle, 0, 0);
            if (target == null) return;
            InputHelper.LeftClick(target.Value.X, target.Value.Y, delay);
            Thread.Sleep(BotApi.IDLE_DELAY);
        }

        public void CloseShopIfOpen(
            int delay = 100
            )
        {
            var handle = Program.GameHandle;
            if (handle == null || handle == IntPtr.Zero) return;

            Point? target = ScreenHelper.GetColorPosition(DEFINE.ColorCloseShop.ToColorRGB().Value, handle, 0, 0);
            if (target == null) return;
            InputHelper.LeftClick(target.Value.X, target.Value.Y, delay);
            Thread.Sleep(BotApi.IDLE_DELAY);
        }

        public bool CheckColorExist(Color color)
        {
            var handle = Program.GameHandle;
            if (handle == null || handle == IntPtr.Zero) return false;

            Point? target = ScreenHelper.GetColorPosition(color, handle, 0, 0);
            if (target == null) return false;
            return true;
        }
    }
}
