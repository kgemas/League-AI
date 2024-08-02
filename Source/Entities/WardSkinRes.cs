using Newtonsoft.Json;

namespace LeagueAI.Libraries.Entities
{
    public sealed class WardSkinRes
    {
        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("id")]
        public long? Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("ownership")]
        public Ownership Ownership { get; set; }

        [JsonProperty("wardImagePath")]
        public string WardImagePath { get; set; }

        [JsonProperty("wardShadowImagePath")]
        public string WardShadowImagePath { get; set; }
    }

    public sealed class Ownership
    {
        [JsonProperty("freeToPlayReward")]
        public bool? FreeToPlayReward { get; set; }

        [JsonProperty("owned")]
        public bool? Owned { get; set; }

        [JsonProperty("rental")]
        public Rental Rental { get; set; }
    }

    public sealed class Rental
    {
        [JsonProperty("endDate")]
        public long? EndDate { get; set; }

        [JsonProperty("purchaseDate")]
        public long? PurchaseDate { get; set; }

        [JsonProperty("rented")]
        public bool? Rented { get; set; }

        [JsonProperty("winCountRemaining")]
        public long? WinCountRemaining { get; set; }
    }
}
