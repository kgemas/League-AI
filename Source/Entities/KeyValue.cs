using Newtonsoft.Json;

namespace LeagueAI.Libraries.Entities
{
    public class KeyValue
    {
        [JsonProperty("key")]
        public string key { get; set; }

        [JsonProperty("value")]
        public string value { get; set; }
    }
}
