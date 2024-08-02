using Newtonsoft.Json;

namespace LeagueAI.Libraries.Entities
{
    public sealed class GameStat
    {
        [JsonProperty("gameMode")]
        public string gameMode { get; set; }

        [JsonProperty("gameTime")]
        public double? gameTime { get; set; }

        [JsonProperty("mapName")]
        public string mapName { get; set; }

        [JsonProperty("mapNumber")]
        public double? mapNumber { get; set; }

        [JsonProperty("mapTerrain")]
        public string mapTerrain { get; set; }
    }
}
