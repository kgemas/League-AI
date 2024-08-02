using Newtonsoft.Json;
using System.Collections.Generic;

namespace LeagueAI.Libraries.Entities
{
    public sealed class Activeplayer
    {
        public ChampionStat championStats { get; set; }
        public Abilities abilities { get; set; }
        public double? currentGold { get; set; }
        public FullRune fullRunes { get; set; }
        public double? level { get; set; }
        public string summonerName { get; set; }
        public bool? teamRelativeColors { get; set; }
    }

    public sealed class FullRune
    {
        public List<Abilities> generalRunes { get; set; }
        public Abilities keystone { get; set; }
        public Abilities primaryRuneTree { get; set; }
        public Abilities secondaryRuneTree { get; set; }
        public List<Abilities> statRunes { get; set; }
    }

    public sealed class Abilities
    {
        [JsonProperty("E")]
        public Ability e { get; set; }

        [JsonProperty("Passive")]
        public Ability passive { get; set; }

        [JsonProperty("Q")]
        public Ability q { get; set; }

        [JsonProperty("R")]
        public Ability r { get; set; }

        [JsonProperty("W")]
        public Ability w { get; set; }
    }

    public sealed class Ability
    {
        [JsonProperty("abilityLevel")]
        public double? abilityLevel { get; set; }

        [JsonProperty("displayName")]
        public string displayName { get; set; }

        [JsonProperty("id")]
        public string id { get; set; }

        [JsonProperty("rawDescription")]
        public string rawDescription { get; set; }

        [JsonProperty("rawDisplayName")]
        public string rawDisplayName { get; set; }
    }

    public sealed class ChampionStat
    {
        public double? abilityHaste { get; set; }
        public double? abilityPower { get; set; }
        public double? armor { get; set; }
        public double? armorPenetrationFlat { get; set; }
        public double? armorPenetrationPercent { get; set; }
        public double? attackDamage { get; set; }
        public double? attackRange { get; set; }
        public double? attackSpeed { get; set; }
        public double? bonusArmorPenetrationPercent { get; set; }
        public double? bonusMagicPenetrationPercent { get; set; }
        public double? critChance { get; set; }
        public double? critDamage { get; set; }
        public double? currentHealth { get; set; }
        public double? healShieldPower { get; set; }
        public double? healthRegenRate { get; set; }
        public double? lifeSteal { get; set; }
        public double? magicLethality { get; set; }
        public double? magicPenetrationFlat { get; set; }
        public double? magicPenetrationPercent { get; set; }
        public double? magicResist { get; set; }
        public double? maxHealth { get; set; }
        public double? moveSpeed { get; set; }
        public double? omnivamp { get; set; }
        public double? physicalLethality { get; set; }
        public double? physicalVamp { get; set; }
        public double? resourceMax { get; set; }
        public double? resourceRegenRate { get; set; }
        public string resourceType { get; set; }
        public double? resourceValue { get; set; }
        public double? spellVamp { get; set; }
        public double? tenacity { get; set; }
    }
}
