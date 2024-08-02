using Newtonsoft.Json;

namespace LeagueAI.Libraries.Entities
{
    public sealed class ItemDto
    {
        [JsonProperty("name")]
        public string Name { get; private set; }

        [JsonProperty("cost")]
        public int Cost { get; private set; }

        public bool Buyed { get; set; }
        public ItemDto(string name, int cost)
        {
            Name = name;
            Cost = cost;
            Buyed = false;
        }
    }
}
