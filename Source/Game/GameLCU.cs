using Leaf.xNet;
using LeagueAI.Libraries.Entities;
using LeagueAI.Libraries.Enums;
using LeagueAI.Libraries.Helper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace LeagueAI.Libraries.Game
{
    public sealed class GameLCU
    {
        public static string ApiUrl { get; set; } = $"https://127.0.0.1:{Configuration.Instance.SettingGame.portApiGame.ToString()}/liveclientdata";

        public static string ActivePlayerUrl { get; set; } = ApiUrl + "/activeplayer";

        public static string PlayerListUrl { get; set; } = ApiUrl + "/playerlist";

        public static string GameStatsUrl { get; set; } = ApiUrl + "/gamestats";

        public static string PlayerItems { get; set; } = ApiUrl + "/playeritems";

        public static bool IsApiReady()
        {
            try
            {
                using (HttpRequest request = CreateRequest())
                {
                    HttpResponse response = request.Get(PlayerListUrl);
                    var statusCode = (int)response.StatusCode;
                    if (statusCode >= 200 && statusCode < 300) return true;
                }
            }
            catch (Exception ex) { Logger.WriteLine(ex, EMessageState.WARNING); }
            return false;
        }

        public static bool IsGameOpen()
        {
            try
            {
                var handle = Program.GameHandle;
                if (handle != null && handle != IntPtr.Zero) return true;
            }
            catch (Exception ex) { Logger.WriteLine(ex, EMessageState.WARNING); }
            return false;
        }

        public static bool IsPlayerDead()
        {
            try
            {
                ChampionStat stat = GetStats();
                if (stat?.currentHealth == null)
                {
                    return false;
                }

                return stat.currentHealth <= 0;
            }
            catch (Exception ex) { Logger.WriteLine(ex); }
            return false;
        }

        public static bool BringToFont()
        {
            try
            {
                var handle = Program.GameHandle;
                handle.BringToFront();
                return true;
            }
            catch (Exception ex) { Logger.WriteLine(ex); }
            return false;
        }

        public static bool CenterScreen()
        {
            try
            {
                var handle = Program.GameHandle;
                return handle.CenterScreen();
            }
            catch (Exception ex) { Logger.WriteLine(ex); }
            return false;
        }

        public static double GetPlayerLevel()
        {
            try
            {
                string resultStr = CreateRequest().Get(ActivePlayerUrl)?.ToString();
                Activeplayer dyn = JsonConvert.DeserializeObject<Activeplayer>(resultStr);
                return dyn?.level ?? -1;
            }
            catch (Exception ex) { Logger.WriteLine(ex, EMessageState.WARNING); }
            return -1;
        }
        public static string GetPlayerName()
        {
            try
            {
                string resultStr = CreateRequest().Get(ActivePlayerUrl)?.ToString();
                Activeplayer dyn = JsonConvert.DeserializeObject<Activeplayer>(resultStr);
                return dyn?.summonerName;
            }
            catch (Exception ex) { Logger.WriteLine(ex, EMessageState.WARNING); }
            return DEFINE.LogCantGetUsername;
        }

        public static double GetGameTime()
        {
            try
            {
                string resultStr = CreateRequest().Get(GameStatsUrl)?.ToString();
                GameStat dyn = JsonConvert.DeserializeObject<GameStat>(resultStr);
                return dyn?.gameTime ?? -1;
            }
            catch (Exception ex) { Logger.WriteLine(ex); }
            return -1;
        }

        public static PlayerList GetAlly(int id)
        {
            try
            {
                string resultStr = CreateRequest().Get(PlayerListUrl)?.ToString();
                List<PlayerList> dyn = JsonConvert.DeserializeObject<List<PlayerList>>(resultStr);
                return dyn[id - 1];
            }
            catch (Exception ex) { Logger.WriteLine(ex); }
            return null;
        }

        public static ESideTeam GetPlayerSide()
        {
            try
            {
                string playerName = GetPlayerName();
                string resultStr = CreateRequest().Get(PlayerListUrl)?.ToString();
                var dyn = JsonConvert.DeserializeObject<List<PlayerList>>(resultStr);
                foreach (PlayerList element in dyn)
                {
                    if (element.summonerName == playerName)
                    {
                        if (element.team == "ORDER")
                            return ESideTeam.ORDER;
                        return ESideTeam.CHAOS;
                    }
                }
            }
            catch (Exception ex) { Logger.WriteLine(ex, EMessageState.WARNING); }
            return ESideTeam.ORDER;
        }

        public static List<Item> GetPlayerItems(string summonerName)
        {
            try
            {
                string resultStr = CreateRequest().Get($"{PlayerItems}?summonerName={System.Web.HttpUtility.HtmlEncode(summonerName)}")?.ToString();
                List<Item> dyn = JsonConvert.DeserializeObject<List<Item>>(resultStr);
                return dyn;
            }
            catch (Exception ex) { Logger.WriteLine(ex); }
            return null;
        }

        public static double GetPlayerGolds()
        {
            try
            {
                string resultStr = CreateRequest().Get(ActivePlayerUrl)?.ToString();
                Activeplayer dyn = JsonConvert.DeserializeObject<Activeplayer>(resultStr);
                return dyn?.currentGold ?? -1;
            }
            catch (Exception ex) { Logger.WriteLine(ex, EMessageState.WARNING); }
            return -1;
        }

        public static List<PlayerList> GetAllies()
        {
            try
            {
                string resultStr = CreateRequest().Get(PlayerListUrl)?.ToString();
                List<PlayerList> dyn = JsonConvert.DeserializeObject<List<PlayerList>>(resultStr);
                return dyn;
            }
            catch (Exception ex) { Logger.WriteLine(ex, EMessageState.WARNING); }
            return null;
        }

        public static ChampionStat GetStats()
        {
            try
            {
                string resultStr = CreateRequest().Get(ActivePlayerUrl)?.ToString();
                Activeplayer dyn = JsonConvert.DeserializeObject<Activeplayer>(resultStr);
                return dyn?.championStats;
            }
            catch (Exception ex) { Logger.WriteLine(ex, EMessageState.WARNING); }
            return null;
        }

        public static void CloseGameProcess()
        {
            try
            {
                var process = Program.GameHandle.GetProcess();
                process.Kill();
            }
            catch (Exception ex) { Logger.WriteLine(ex); }
        }

        private static HttpRequest CreateRequest()
        {
            HttpRequest request = new HttpRequest
            {
                IgnoreProtocolErrors = true,
                CharacterSet = DEFINE.HttpRequestEncoding,
            };
            return request;
        }
    }
}
