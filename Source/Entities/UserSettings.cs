using Newtonsoft.Json;
using System.Collections.Generic;

namespace LeagueAI.Libraries.Entities
{
    public class PersistedSetting
    {
        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("files")]
        public List<FileConfig> Files { get; set; }
    }

    public class FileConfig
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("sections")]
        public List<Section> Sections { get; set; }
    }

    public class Section
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("settings")]
        public List<Setting> Settings { get; set; }
    }

    public class Setting
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }
    }
}
