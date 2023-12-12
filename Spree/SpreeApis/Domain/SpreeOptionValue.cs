using Newtonsoft.Json;

namespace SpreeApis.Domain
{
    public class SpreeOptionValue
    {  
        public long SpreeOptionValueId { get; set; }
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("presentation")]
        public string Presentation { get; set; }

        [JsonProperty("position", NullValueHandling = NullValueHandling.Ignore)]
        public long? Position { get; set; }
    }
}
