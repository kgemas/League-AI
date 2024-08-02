using Leaf.xNet;
using LeagueAI.Libraries.Entities;
using LeagueAI.Libraries.Enums;
using LeagueAI.Libraries.Helper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;

namespace LeagueAI.Libraries.Game
{
    public sealed class ClientLCU
    {
        private static string Auth;
        private static int Port;

        private static string Url => "https://127.0.0.1:" + Port + "/";
        private static string LoginUrl => Url + "lol-login/v1/session";
        private static string CreateLobbyURL => Url + "lol-lobby/v2/lobby";
        private static string SearchURL => Url + "lol-lobby/v2/lobby/matchmaking/search";
        private static string ReconnectUrl => Url + "lol-gameflow/v1/reconnect";
        private static string AcceptURL => Url + "lol-matchmaking/v1/ready-check/accept";
        private static string PickURL => Url + "lol-champ-select/v1/session/actions/";
        private static string PickSkinSpellWardSkinURL => Url + "lol-champ-select/v1/session/my-selection";
        private static string SessionURL => Url + "lol-champ-select/v1/session";
        private static string LoginURL => Url + "rso-auth/v1/session/credentials";
        private static string HonorURL => Url + "lol-honor-v2/v1/honor-player";
        private static string GetHonorDataUrl => Url + "lol-honor-v2/v1/ballot";
        private static string PickRandomChampionsUrl => Url + "lol-champ-select/v1/session/simple-inventory";
        private static string PickableSkinIdUrl => Url + "lol-champ-select/v1/skin-carousel-skins";
        private static string PickableSpellIdUrl => Url + "lol-collections/v1/inventories/{0}/spells";
        private static string PickableWardSkinIdUrl => Url + "lol-collections/v1/inventories/{0}/ward-skins";
        private static string PickableChampionsUrl => Url + "lol-champ-select/v1/pickable-champion-ids";
        private static string BannableChampionIdUrl => Url + "lol-champ-select/v1/bannable-champion-ids";
        private static string DisableChampionIdUrl => Url + "lol-champ-select/v1/disabled-champions";
        private static string KillUXUrl => Url + "riotclient/kill-ux";
        private static string GameflowAvailabilityUrl => Url + "lol-gameflow/v1/availability";
        private static string GameflowPhaseUrl => Url + "lol-gameflow/v1/gameflow-phase";
        private static string CurrentSummonerUrl => Url + "lol-summoner/v1/current-summoner";

        public static void NetworkChanged(object sender, NetworkAvailabilityEventArgs e)
        {
            try
            {
                if (!e.IsAvailable || !IsApiReady())
                {
                    Thread.Sleep(12000);
                    NetworkChanged(sender, e);
                    return;
                }
                using (HttpRequest request = CreateRequest())
                {
                    var response = request.Post(ReconnectUrl);
                    if (response?.IsOK == true) Logger.WriteLine(DEFINE.Reconnected, EMessageState.SUCCES);
                }
            }
            catch (Exception ex) { Logger.WriteLine(ex); }
        }

        static ClientLCU()
        {
            NetworkChange.NetworkAvailabilityChanged += NetworkChanged;
        }

        public static bool IsApiReady()
        {
            try
            {
                using (HttpRequest request = CreateRequest())
                {
                    HttpResponse response = request.Get(GameflowAvailabilityUrl);

                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        Availability obj = JsonConvert.DeserializeObject<Availability>(response.ToString());
                        return obj?.isAvailable ?? false;
                    }
                }
            }
            catch (Exception ex) { Logger.WriteLine(ex); }
            return false;
        }

        public static bool BringToFont()
        {
            try
            {
                var handle = Program.ClientHandle;
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
                var handle = Program.ClientHandle;
                return handle.CenterScreen();
            }
            catch (Exception ex) { Logger.WriteLine(ex); }
            return false;
        }

        public static bool IsClientOpen()
        {
            try
            {
                var handle = Program.ClientHandle;
                if (handle != null && handle != IntPtr.Zero) return true;
            }
            catch (Exception ex) { Logger.WriteLine(ex, EMessageState.WARNING); }
            return false;
        }

        public static void Initialize()
        {
            try
            {
                // Tạo môi trường để sử dụng API Client
                string path = Configuration.Instance.LockfilePath;

                if (!File.Exists(path))
                {
                    Logger.WriteLine(DEFINE.NotOpenGameClientYetLog, EMessageState.ERROR);
                    Program.Exit(1);
                }

                using (FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                {
                    using (StreamReader streamReader = new StreamReader(fileStream, Encoding.Default))
                    {
                        string line;
                        while ((line = streamReader.ReadLine()) != null)
                        {
                            string[] lines = line.Split(':');
                            // string pid = lines[1];
                            Port = int.Parse(lines[2]);
                            string riot_pass = lines[3];
                            // string protocalTranfer = lines[4];
                            Auth = Convert.ToBase64String(Encoding.UTF8.GetBytes("riot:" + riot_pass));
                            Logger.WriteLine(string.Format(DEFINE.WriteAccessAPI, Port, riot_pass), EMessageState.SUCCES);

                            if (Port == 0) Logger.WriteLine(DEFINE.CantLoadGameAPILog, EMessageState.ERROR);
                        }
                    }
                }
            }
            catch (Exception ex) { Logger.WriteLine(ex); }
        }

        public static bool IsMatchFound() => GetGameflowPhase() == EGameflowPhase.ReadyCheck;

        public static bool CreateLobby(EQueueRoom queueId)
        {
            try
            {
                using (HttpRequest request = CreateRequest())
                {
                    string response = request.Post(CreateLobbyURL, "{\"queueId\": " + (int)queueId + "}", "application/json").StatusCode.ToString();

                    if (response == "OK")
                    {
                        return true;
                    }
                }
            }
            catch (Exception ex) { Logger.WriteLine(ex); }
            return false;
        }

        public static ESearchMatchResult SearchMatch()
        {
            try
            {
                using (HttpRequest request = CreateRequest())
                {
                    string response = request.Post(SearchURL).ToString();

                    if (string.IsNullOrWhiteSpace(response))
                        return ESearchMatchResult.Ok;

                    ESearchMatchResult result = ESearchMatchResult.Unknown;
                    dynamic obj = JsonConvert.DeserializeObject(response);
                    string message = obj.message;
                    switch (message)
                    {
                        case "GATEKEEPER_RESTRICTED":
                            result = ESearchMatchResult.GatekeeperRestricted;
                            break;
                        case "QUEUE_NOT_ENABLED":
                            result = ESearchMatchResult.QueueNotEnabled;
                            break;
                        case "INVALID_LOBBY":
                            result = ESearchMatchResult.InvalidLobby;
                            break;
                        default:
                            Logger.WriteLine(string.Format(DEFINE.CantFindGameLog, obj?.message), EMessageState.WARNING);
                            break;
                    }

                    return result;
                }
            }
            catch (Exception ex) { Logger.WriteLine(ex); }
            return ESearchMatchResult.Unknown;
        }
        public static EGameflowPhase GetGameflowPhase()
        {
            try
            {
                using (HttpRequest request = CreateRequest())
                {
                    string result = request.Get(GameflowPhaseUrl)?.ToString();
                    result = Regex.Match(result, "\"(.*)\"").Groups[1].Value;
                    return (EGameflowPhase)Enum.Parse(typeof(EGameflowPhase), result);
                }
            }
            catch (Exception ex) { Logger.WriteLine(ex); }
            return EGameflowPhase.None;
        }

        public static Summoner GetCurrentSummoner()
        {
            try
            {
                using (HttpRequest request = CreateRequest())
                {
                    string result = request.Get(CurrentSummonerUrl).ToString();
                    return JsonConvert.DeserializeObject<Summoner>(result);
                }
            }
            catch (Exception ex) { Logger.WriteLine(ex); }
            return null;
        }

        public static LobbySession GetChampSelectSession()
        {
            try
            {
                using (HttpRequest request = CreateRequest())
                {
                    string result = request.Get(SessionURL).ToString();
                    return JsonConvert.DeserializeObject<LobbySession>(result);
                }
            }
            catch (Exception ex) { Logger.WriteLine(ex); }
            return default;
        }

        public static void Reconnect()
        {
            try
            {
                using (HttpRequest request = CreateRequest())
                {
                    request.Post(ReconnectUrl);
                }
            }
            catch (Exception ex) { Logger.WriteLine(ex); }
        }

        public static void AcceptMatch()
        {
            try
            {
                using (HttpRequest request = CreateRequest())
                {
                    request.Post(AcceptURL);
                }
            }
            catch (Exception ex) { Logger.WriteLine(ex); }
        }

        public static int[] GetPickableChampions()
        {
            try
            {
                // Lấy danh sách tướng có thể chọn
                using (HttpRequest request = CreateRequest())
                {
                    string result = request.Get(PickableChampionsUrl).ToString();
                    result = Regex.Match(result, @"\[(.*)\]").Groups[1].Value;
                    return result.Split(',').Select(int.Parse).ToArray();
                }
            }
            catch (Exception ex) { Logger.WriteLine(ex); }
            return default;
        }

        public static int[] GetBannableChampions()
        {
            try
            {
                // Lấy danh sách tướng có thể chọn
                using (HttpRequest request = CreateRequest())
                {
                    string result = request.Get(BannableChampionIdUrl).ToString();
                    result = Regex.Match(result, @"\[(.*)\]").Groups[1].Value;
                    return result.Split(',').Select(int.Parse).ToArray();
                }
            }
            catch (Exception ex) { Logger.WriteLine(ex); }
            return default;
        }

        public static HonorGame GetHonorAfterGameDone()
        {
            try
            {
                // Lấy danh sách tướng có thể chọn
                using (HttpRequest request = CreateRequest())
                {
                    string result = request.Get(GetHonorDataUrl).ToString();
                    return JsonConvert.DeserializeObject<HonorGame>(result);
                }
            }
            catch (Exception ex) { Logger.WriteLine(ex); }
            return default;
        }

        public static string PostHonorAfterGameDone()
        {
            try
            {
                HonorGame data = GetHonorAfterGameDone();
                if (data == null || data.GameId == null || data.EligiblePlayers?.Count <= 0) return null;

                var idHonor = data.EligiblePlayers[new Random().Next(0, data.EligiblePlayers.Count)];
                if (idHonor?.summonerId == null) return null;

                using (HttpRequest request = CreateRequest())
                {
                    string result = request.Post(HonorURL, JsonConvert.SerializeObject(new
                    {
                        gameId = data.GameId,
                        honorCategory = "Friendly",
                        summonerId = idHonor.summonerId,
                    })).ToString();
                    return result;
                }
            }
            catch (Exception ex) { Logger.WriteLine(ex); }
            return default;
        }

        public static int[] GetDisableChampions()
        {
            try
            {
                // Lấy danh sách tướng có thể chọn
                using (HttpRequest request = CreateRequest())
                {
                    string result = request.Get(DisableChampionIdUrl).ToString();
                    result = Regex.Match(result, @"\[(.*)\]").Groups[1].Value;
                    return result.Split(',').Select(int.Parse).ToArray();
                }
            }
            catch (Exception ex) { Logger.WriteLine(ex); }
            return default;
        }

        public static EChampionPickResult PickChampion(
            EChampion champion)
        {
            try
            {
                // Lựa chọn tướng
                LobbySession session = ClientLCU.GetChampSelectSession();

                foreach (ActionGame summoner in session.actions[0])
                {
                    if (summoner.championId == (int)champion)
                    {
                        return EChampionPickResult.ChampionPicked;
                    }
                }

                int[] pickableChampions = GetPickableChampions();

                if (!pickableChampions.Contains((int)champion))
                {
                    return EChampionPickResult.ChampionNotOwned;
                }

                int championId = (int)champion;

                for (int id = 0; id < 10; id++)
                {
                    using (HttpRequest request = CreateRequest())
                    {
                        string result = request.Patch(
                            address: PickURL + id,
                            str: JsonConvert.SerializeObject(new
                            {
                                actorCellId = 0,
                                championId = championId,
                                completed = true,
                                id = id,
                                isAllyAction = true,
                                type = "string",
                            }),
                            contentType: "application/json").ToString();
                    }
                }

                return EChampionPickResult.Ok;
            }
            catch (Exception ex) { Logger.WriteLine(ex); }
            return EChampionPickResult.ChampionNotOwned;
        }

        public static bool PickSkin(Summoner player)
        {
            try
            {
                var random = new Random();

                // get available skin
                var skins = new List<SkinRes>();
                using (HttpRequest request = CreateRequest())
                {
                    var res = request.Get(
                        address: PickableSkinIdUrl)?.ToString();
                    skins = JsonConvert.DeserializeObject<List<SkinRes>>(res)?.Where(m => m.Unlocked == true)?.ToList();
                    if (skins?.Count < 1) return false;
                }

                // get available spell
                var spells = new SpellRes();
                using (HttpRequest request = CreateRequest())
                {
                    var res = request.Get(
                        address: string.Format(PickableSpellIdUrl, player.summonerId))?.ToString();
                    spells = JsonConvert.DeserializeObject<SpellRes>(res);
                }

                // get available ward skin
                var wardSkins = new List<WardSkinRes>();
                using (HttpRequest request = CreateRequest())
                {
                    var res = request.Get(
                        address: string.Format(PickableWardSkinIdUrl, player.summonerId))?.ToString();
                    wardSkins = JsonConvert.DeserializeObject<List<WardSkinRes>>(res);
                }

                // submit
                using (HttpRequest request = CreateRequest())
                {
                    var result = request.Patch(
                        address: PickSkinSpellWardSkinURL,
                        str: JsonConvert.SerializeObject(new
                        {
                            selectedSkinId = skins[random.Next(0, skins.Count)].Id,
                            spell1Id = ESpell.Exhaust.ToInt(),
                            spell2Id = ESpell.Ignite.ToInt(),
                            wardSkinId = wardSkins[random.Next(0, wardSkins.Count)].Id,
                        }),
                        contentType: "application/json");
                    if (result.StatusCode.IsSuccess()) return true;
                }
            }
            catch (Exception ex) { Logger.WriteLine(ex); }
            return false;
        }

        public static void KillProcessRenderUxClient()
        {
            var process = Process.GetProcesses();
            foreach (var item in process)
            {
                try
                {
                    if (item?.MainModule?.FileName?.Contains(DEFINE.LeagueClientUxRender) == true) item.Kill();
                }
                catch (Exception) { }
            }
        }

        public static void CloseClient()
        {
            try
            {
                using (HttpRequest request = CreateRequest())
                {
                    request.Post(KillUXUrl);
                }
            }
            catch (Exception ex) { Logger.WriteLine(ex); }
        }

        public static void ForceKillClient()
        {
            try
            {
                Process[] process = Process.GetProcessesByName(Configuration.Instance.ClientHostProcessName);
                foreach (Process item in process)
                {
                    item.Kill();
                }
            }
            catch (Exception ex) { Logger.WriteLine(ex); }
        }

        public static void OpenClient()
        {
            try
            {
                if (IsClientOpen()) return;

                ProcessStartInfo psi = new ProcessStartInfo
                {
                    FileName = Configuration.Instance.ClientExecutablePath
                };
                Process.Start(psi);
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
            request.AddHeader("Authorization", "Basic " + Auth);
            return request;
        }

    }
}
