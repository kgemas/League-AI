using Newtonsoft.Json;

namespace LeagueAI.Libraries.Entities
{
    public class IpInfoDto
    {

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("continent")]
        public string Continent { get; set; }

        [JsonProperty("continentCode")]
        public string ContinentCode { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("countryCode")]
        public string CountryCode { get; set; }

        [JsonProperty("region")]
        public string Region { get; set; }

        [JsonProperty("regionName")]
        public string RegionName { get; set; }

        [JsonProperty("city")]
        public string City { get; set; }

        [JsonProperty("district")]
        public string District { get; set; }

        [JsonProperty("zip")]
        public string Zip { get; set; }

        [JsonProperty("lat")]
        public double? Lat { get; set; }

        [JsonProperty("lon")]
        public double? Lon { get; set; }

        [JsonProperty("timezone")]
        public string Timezone { get; set; }

        [JsonProperty("offset")]
        public int? Offset { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("isp")]
        public string Isp { get; set; }

        [JsonProperty("org")]
        public string Org { get; set; }

        [JsonProperty("as")]
        public string As { get; set; }

        [JsonProperty("asname")]
        public string Asname { get; set; }

        [JsonProperty("reverse")]
        public string Reverse { get; set; }

        [JsonProperty("mobile")]
        public bool? Mobile { get; set; }

        [JsonProperty("proxy")]
        public bool? Proxy { get; set; }

        [JsonProperty("hosting")]
        public bool? Hosting { get; set; }

        [JsonProperty("query")]
        public string Query { get; set; }
    }
}
