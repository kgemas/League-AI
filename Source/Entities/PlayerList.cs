using System.Collections.Generic;

namespace LeagueAI.Libraries.Entities
{
    public sealed class PlayerList
    {
        public string championName { get; set; }
        public bool? isBot { get; set; }
        public bool? isDead { get; set; }
        public List<Item> items { get; set; }
        public int? level { get; set; }
        public string position { get; set; }
        public string rawChampionName { get; set; }
        public double? respawnTimer { get; set; }
        public FullRune runes { get; set; }
        public Score scores { get; set; }
        public int? skinID { get; set; }
        public string summonerName { get; set; }
        public SummonerSpell summonerSpells { get; set; }
        public string team { get; set; }
    }

    public sealed class SummonerSpell
    {
        public Ability summonerSpellOne { get; set; }
        public Ability summonerSpellTwo { get; set; }
    }

    public sealed class Score
    {
        public double? assists { get; set; }
        public double? creepScore { get; set; }
        public double? deaths { get; set; }
        public double? kills { get; set; }
        public double? wardScore { get; set; }
    }

    public sealed class Item
    {
        public bool? canUse { get; set; }
        public bool? consumable { get; set; }
        public int? count { get; set; }
        public string displayName { get; set; }
        public int? itemID { get; set; }
        public int? price { get; set; }
        public string rawDescription { get; set; }
        public string rawDisplayName { get; set; }
        public int? slot { get; set; }
    }
}
