using Newtonsoft.Json;
using SpreeModel;

namespace SpreeApis.Domain
{
    public class SpreeProperty
    {
        public long SpreePropertyId { get; set; }
        [JsonProperty("id")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long Id { get; set; }
        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }
        [JsonProperty("value", NullValueHandling = NullValueHandling.Ignore)]
        public string Value { get; set; }

        [JsonProperty("filter_param", NullValueHandling = NullValueHandling.Ignore)]
        public string FilterParam { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }
    }
}
