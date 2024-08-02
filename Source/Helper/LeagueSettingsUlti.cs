using LeagueAI.Libraries.Entities;
using LeagueAI.Libraries.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace LeagueAI.Libraries.Helper
{
    public sealed class LeagueSettingsUlti
    {
        public static void ApplySettings()
        {
            // Cài đặt cửa sổ game
            string gamCFG = Configuration.Instance.LeagueGameconfigPath;
            ConfigCFGFile config = new ConfigCFGFile(gamCFG);
            JToken settings = (JToken)Configuration.Instance.SettingGame?.inGame;
            foreach (JProperty x in settings)
            {
                config.ReplaceSetting(x.Name, x.Value?.ToString());
            }

            config.ReplaceSetting(nameof(DEFINE.AutoAcquireTarget), DEFINE.AutoAcquireTarget);
            config.ReplaceSetting(nameof(DEFINE.WindowMode), DEFINE.WindowMode);

            config.Save();
            Logger.WriteLine(DEFINE.SettingScreenLog, EMessageState.SUCCES);

            // Cài đặt riêng của người dùng
            PersistedSetting setting = null;
            PersistedSetting(ref setting, DEFINE.LeagueGameconfigPath, "General", nameof(DEFINE.AutoAcquireTarget), DEFINE.AutoAcquireTarget);
            PersistedSetting(ref setting, DEFINE.LeagueGameconfigPath, "HUD", "CameraLockMode", "0");
            PersistedSetting(ref setting, DEFINE.LeagueGameconfigPath, "HUD", "MinimapScale", "1.0000");
            File.WriteAllText(
                Configuration.Instance.LeaguePersistedSettingsPath,
                JsonConvert.SerializeObject(setting, Formatting.Indented));

            Logger.WriteLine(DEFINE.SettingKeyboardLog, EMessageState.SUCCES);
        }

        private static void PersistedSetting(ref PersistedSetting setting, string fileName, string sectionName, string settingName, string settingValue)
        {
            if (setting == null)
            {
                var persistedSetting = SystemHelper.SafeReadFile(Configuration.Instance.LeaguePersistedSettingsPath);
                setting = JsonConvert.DeserializeObject<PersistedSetting>(persistedSetting);
            }
            var indexGameCFG = setting.Files.FindIndex(m => m.Name == fileName);
            if (indexGameCFG >= 0)
            {
                var gamecfg = setting.Files[indexGameCFG];
                var indexGenerel = gamecfg.Sections.FindIndex(m => m.Name == sectionName);

                if (indexGenerel >= 0)
                {
                    var generel = gamecfg.Sections[indexGenerel];
                    var item = generel.Settings.FirstOrDefault(m => m.Name == settingName);
                    if (item == default) generel.Settings.Add(new Setting()
                    {
                        Name = settingName,
                        Value = settingValue
                    });
                    else
                        item.Value = settingValue;
                }
                else
                {
                    gamecfg.Sections.Add(new Section()
                    {
                        Name = sectionName,
                        Settings = new List<Setting>()
                        {
                            new Setting()
                            {
                                Name = settingName,
                                Value = settingValue
                            }
                        }
                    });
                }

            }
            else
            {
                setting.Files.Add(new FileConfig()
                {
                    Name = fileName,
                    Sections = new List<Section>()
                    {
                        new Section() { Name = sectionName, Settings = new List<Setting>()
                        {
                            new Setting()
                            {
                                Name = settingName,
                                Value = settingValue
                            }
                        }
                    } }
                });
            }
        }
    }

    public sealed class ConfigCFGFile
    {
        private string Filepath { get; set; } = null;
        private string[] Content { get; set; } = null;

        public ConfigCFGFile(string filePath)
        {
            Content = File.ReadAllLines(filePath);
            Filepath = filePath;
        }

        public void ReplaceSetting(string key, string value)
        {
            for (int i = 0; i < Content.Length; i++)
            {
                if (Content[i].StartsWith($"{key}="))
                {
                    Content[i] = $"{key}={value}";
                }
            }
        }

        public void Save()
        {
            File.WriteAllLines(Filepath, Content);
        }
    }
}
