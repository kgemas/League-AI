using LeagueAI.Libraries.Enums;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace LeagueAI.Libraries.Entities
{
    public sealed class SpellRes
    {
        [JsonProperty("spells")]
        public List<ESpell> Spells { get; set; }

        [JsonProperty("summonerId")]
        public long? SummonerId { get; set; }
    }
}
