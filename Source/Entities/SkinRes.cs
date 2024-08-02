using Newtonsoft.Json;
using System.Collections.Generic;

namespace LeagueAI.Libraries.Entities
{
    public sealed class SkinRes
    {
        [JsonProperty("championId")]
        public long? ChampionId { get; set; }

        [JsonProperty("childSkins")]
        public List<ChildSkin> ChildSkins { get; set; }

        [JsonProperty("chromaPreviewPath")]
        public string ChromaPreviewPath { get; set; }

        [JsonProperty("disabled")]
        public bool? Disabled { get; set; }

        [JsonProperty("emblems")]
        public List<object> Emblems { get; set; }

        [JsonProperty("groupSplash")]
        public string GroupSplash { get; set; }

        [JsonProperty("id")]
        public long? Id { get; set; }

        [JsonProperty("isBase")]
        public bool? IsBase { get; set; }

        [JsonProperty("isChampionUnlocked")]
        public bool? IsChampionUnlocked { get; set; }

        [JsonProperty("isUnlockedFromEntitledFeature")]
        public bool? IsUnlockedFromEntitledFeature { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("ownership")]
        public Ownership Ownership { get; set; }

        [JsonProperty("rarityGemPath")]
        public string RarityGemPath { get; set; }

        [JsonProperty("splashPath")]
        public string SplashPath { get; set; }

        [JsonProperty("splashVideoPath")]
        public string SplashVideoPath { get; set; }

        [JsonProperty("stillObtainable")]
        public bool? StillObtainable { get; set; }

        [JsonProperty("tilePath")]
        public string TilePath { get; set; }

        [JsonProperty("unlocked")]
        public bool? Unlocked { get; set; }
    }

    public class ChildSkin
    {
        [JsonProperty("championId")]
        public long? ChampionId { get; set; }

        [JsonProperty("chromaPreviewPath")]
        public string ChromaPreviewPath { get; set; }

        [JsonProperty("colors")]
        public List<string> Colors { get; set; }

        [JsonProperty("disabled")]
        public bool? Disabled { get; set; }

        [JsonProperty("id")]
        public long? Id { get; set; }

        [JsonProperty("isBase")]
        public bool? IsBase { get; set; }

        [JsonProperty("isChampionUnlocked")]
        public bool? IsChampionUnlocked { get; set; }

        [JsonProperty("isUnlockedFromEntitledFeature")]
        public bool? IsUnlockedFromEntitledFeature { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("ownership")]
        public Ownership Ownership { get; set; }

        [JsonProperty("parentSkinId")]
        public long? ParentSkinId { get; set; }

        [JsonProperty("shortName")]
        public string ShortName { get; set; }

        [JsonProperty("splashPath")]
        public string SplashPath { get; set; }

        [JsonProperty("splashVideoPath")]
        public object SplashVideoPath { get; set; }

        [JsonProperty("stage")]
        public long? Stage { get; set; }

        [JsonProperty("stillObtainable")]
        public bool? StillObtainable { get; set; }

        [JsonProperty("tilePath")]
        public string TilePath { get; set; }

        [JsonProperty("unlocked")]
        public bool? Unlocked { get; set; }
    }
}
