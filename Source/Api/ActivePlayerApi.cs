using LeagueAI.Libraries.Entities;
using LeagueAI.Libraries.Game;
using LeagueAI.Libraries.Helper;
using LeagueAI.Libraries.Interfaces;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading;

namespace LeagueAI.Libraries.Api
{
    public sealed class ActivePlayerApi : BaseApiMember<GameApi>
    {
        private readonly Dictionary<string, string> upgradeSkillMap;
        public ActivePlayerApi(GameApi api) : base(api)
        {
            // Khởi tạo thứ tự cộng kỹ năng
            if (File.Exists(DEFINE.ConfigPath))
            {
                var content = "";
                using (FileStream fileStream = new FileStream(DEFINE.ConfigPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                {
                    using (StreamReader streamReader = new StreamReader(fileStream, Encoding.Default))
                    {
                        content = streamReader.ReadToEnd();
                    }
                }
                JObject jobj = JObject.Parse(content);
                Dictionary<string, string> dictation = jobj?["SettingGame"]?["upgrandSkillMap"]?.ToObject<Dictionary<string, string>>();
                upgradeSkillMap = dictation;
                return;
            }

            upgradeSkillMap = new Dictionary<string, string>()
            {
                { "1", "Q" },
                { "2", "W" },
                { "3", "E" },
                { "4", "Q" },
                { "5", "W" },
                { "6", "R" },
                { "7", "Q" },
                { "8", "W" },
                { "9", "Q" },
                { "10", "W" },
                { "11", "R" },
                { "12", "Q" },
                { "13", "W" },
                { "14", "E" },
                { "15", "E" },
                { "16", "R" },
                { "17", "E" },
                { "18", "E" },
                { "19", "Q" },
                { "20", "W" },
                { "21", "E" },
                { "22", "R" },
            };
        }

        public IEntity GetNearEnemyPosition()
        {
            var handle = Program.GameHandle;
            if (handle == null || handle == IntPtr.Zero) return null;

            // Lấy toạ độ của kẻ địch đang tấn công
            Point? target = ScreenHelper.GetColorPosition(DEFINE.ColorEnemyFocus.ToColorRGB().Value, handle);
            if (target != null) return new Minion(new Point(target.Value.X, target.Value.Y));

            // Lấy toạ độ của kẻ địch trên màn hinh
            target = ScreenHelper.GetColorPosition(DEFINE.ColorEnemyLevelBox.ToColorRGB().Value, handle, deviantX: 30, deviantY: 30);
            if (target != null) return new Minion(new Point(target.Value.X, target.Value.Y));

            // Lấy toạ độ của creep địch
            target = ScreenHelper.GetColorPosition(DEFINE.ColorEnemyCreep.ToColorRGB().Value, handle);
            if (target != null) return new Minion(new Point(target.Value.X, target.Value.Y));

            return null;
        }

        public void TryCastSpellOnTarget(
            string skill,
            int delay
            )
        {
            // Tung kỹ năng vào vị trí kẻ địch gần nhất
            IEntity target = GetNearEnemyPosition();

            if (target == null) return;

            skill = skill.ToUpper();
            InputHelper.MoveMouse(target.Position.X, target.Position.Y);
            InputHelper.PressKey(skill, delay);
            Thread.Sleep(BotApi.IDLE_DELAY);
        }

        public void TryNormalAttack(char keyAttack = 'a', int delay = 100)
        {
            IEntity target = GetNearEnemyPosition();

            if (target == null) return;

            InputHelper.PressKey(keyAttack.ToString(), delay);
            InputHelper.MoveMouse(target.Position.X, target.Position.Y);
            Thread.Sleep(BotApi.IDLE_DELAY);
        }

        public void UpgradeSpell(
            string skill
            )
        {
            // Lên cấp skill bằng phím tắt ctrl + skill
            InputHelper.KeyDown("ControlKey", 50);
            InputHelper.KeyDown(skill, 50);
            Thread.Sleep(BotApi.IDLE_DELAY);
            InputHelper.KeyUp(skill, 50);
            InputHelper.KeyUp("ControlKey", 50);
            Thread.Sleep(BotApi.IDLE_DELAY);
        }

        public void UpgradeSpellOnLevelUp(double level = -1)
        {
            if (level <= 0)
                return;

            if (upgradeSkillMap.TryGetValue(level.ToString(), out string skill))
                UpgradeSpell(skill);
        }

        public double GetHealthPercent()
        {
            // Lấy ra % máu hiện tại.
            ChampionStat stats = GameLCU.GetStats();
            if (stats?.currentHealth != null
                && stats?.maxHealth != null)
            {
                return (stats?.currentHealth ?? 10) / (stats?.maxHealth ?? 100);
            }

            return -1;
        }

        public double GetManaPercent()
        {
            // Lấy ra % mana hiện tại.
            ChampionStat stats = GameLCU.GetStats();
            if (stats?.resourceValue != null
                && stats?.resourceMax != null)
            {
                return (stats?.resourceValue ?? 10) / (stats?.resourceMax ?? 100);
            }

            return -1;
        }

        public double GetLevel() => GameLCU.GetPlayerLevel();

        public double GetGolds() => GameLCU.GetPlayerGolds();

        public List<Item> GetItemBuyed(string summonerName) => GameLCU.GetPlayerItems(summonerName);

        public string GetName() => GameLCU.GetPlayerName();

        public bool IsDead() => GameLCU.IsPlayerDead();

        public void Recall(int delay)
        {
            InputHelper.PressKey("B", 50);
            Thread.Sleep(delay);
        }

        public void TryCastSpellOnTarget(char skill, int delay) => TryCastSpellOnTarget(skill.ToString(), delay);
    }
}
