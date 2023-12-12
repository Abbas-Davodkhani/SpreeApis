using Newtonsoft.Json;

namespace SpreeApis.Domain
{
    public class SpreeOptionType
    {
        public long SpreeOptionTypeId { get; set; }
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("presentation")]
        public string Presentation { get; set; }
        [JsonProperty("position", NullValueHandling = NullValueHandling.Ignore)]
        public long? Position { get; set; }

        [JsonProperty("option_values", NullValueHandling = NullValueHandling.Ignore)]
        public List<SpreeOptionValue> OptionValues { get; set; }
    }
}
