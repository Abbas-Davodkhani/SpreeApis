using Newtonsoft.Json;
using SpreeModel;

namespace SpreeApis.Domain
{
    public class SpreeStyle
    {
        public long SpreeStyleId { get; set; }
        public long? SpreeImageId { get; set; }
        public SpreeImage? SpreeImage { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("size")]
        public string Size { get; set; }

        [JsonProperty("width")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long Width { get; set; }

        [JsonProperty("height")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long Height { get; set; }
        public long ImageId { get; set; }
    }
}
