using Newtonsoft.Json;
using System.Collections.Generic;

namespace LeagueAI.Libraries.Entities
{
    public class HonorGame
    {
        [JsonProperty("eligiblePlayers")]
        public List<EligiblePlayers> EligiblePlayers { get; set; }

        [JsonProperty("gameId")]
        public double? GameId { get; set; }
    }

    public sealed class EligiblePlayers
    {
        [JsonProperty("championId")]
        public int? championId { get; set; }

        [JsonProperty("skinIndex")]
        public int? skinIndex { get; set; }

        [JsonProperty("skinName")]
        public string skinName { get; set; }

        [JsonProperty("summonerId")]
        public double? summonerId { get; set; }

        [JsonProperty("summonerName")]
        public string summonerName { get; set; }
    }
}
