using LeagueAI.Libraries.Enums;
using LeagueAI.Libraries.Helper;
using System;
using System.IO;
using System.Text;

namespace LeagueAI.Libraries
{
    public sealed class Configuration
    {
        public string Version { get; set; }
        public string ClientProcessName { get; set; }
        public string ClientHostProcessName { get; set; }
        public string GameProcessName { get; set; }
        public string ClientExecutablePath { get; set; }
        public string DefaultLeaguePath { get; set; }
        public string LeagueGameconfigPath { get; set; }
        public string LockfilePath { get; set; }
        public string LeaguePersistedSettingsPath { get; set; }
        public dynamic SettingGame { get; set; }

        public static Configuration Instance { get; private set; } = new Configuration();
        public static bool Initialize()
        {
            try
            {
                var content = "";
                using (FileStream fileStream = new FileStream(DEFINE.ConfigPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                {
                    using (StreamReader streamReader = new StreamReader(fileStream, Encoding.Default))
                    {
                        content = streamReader.ReadToEnd();
                    }
                }

                Instance = DataConvertUlti.DeserializeJson<Configuration>(content);
                return true;
            }
            catch (Exception ex)
            {
                Logger.WriteLine(ex.Message, EMessageState.ERROR);
                Logger.WriteLine(string.Format(DEFINE.CantLoadConfigLog, DEFINE.ConfigPath));
            }
            Program.Exit(1);
            return false;
        }

        public void Init()
        {
            Instance = new Configuration()
            {
                DefaultLeaguePath = null,
                ClientExecutablePath = null,
                ClientHostProcessName = null,
                ClientProcessName = null,
                GameProcessName = null,
                LeagueGameconfigPath = null,
                LockfilePath = null,
                LeaguePersistedSettingsPath = null,
                SettingGame = null,
            };
        }

        public void Save(string path = DEFINE.ConfigPath)
        {
            File.WriteAllText(path, DataConvertUlti.SerializeJson(this));
        }
    }
}
