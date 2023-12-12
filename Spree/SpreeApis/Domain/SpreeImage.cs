using Newtonsoft.Json;
using SpreeModel;

namespace SpreeApis.Domain
{
    public class SpreeImage
    {
        public long SpreeImageId { get; set; }
        [JsonProperty("id")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long Id { get; set; }
        [JsonProperty("transformed_url")]
        public string TransformedUrl { get; set; }
        [JsonProperty("position", NullValueHandling = NullValueHandling.Ignore)]
        public long? Position { get; set; }
        [JsonProperty("alt", NullValueHandling = NullValueHandling.Ignore)]
        public string Alt { get; set; }

        [JsonProperty("original_url", NullValueHandling = NullValueHandling.Ignore)]
        public string OriginalUrl { get; set; }

        public ICollection<SpreeStyle> Styles { get; set; }
    }
}
