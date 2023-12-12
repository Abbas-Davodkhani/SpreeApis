using Newtonsoft.Json;
using SpreeModel;

namespace SpreeApis.Domain
{
    public class SpreeTaxon
    {
        public long SpreeTaxonId { get; set; }
        [JsonProperty("id")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long Id { get; set; }
        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }
        [JsonProperty("pretty_name", NullValueHandling = NullValueHandling.Ignore)]
        public string PrettyName { get; set; }

        [JsonProperty("permalink", NullValueHandling = NullValueHandling.Ignore)]
        public string Permalink { get; set; }

        [JsonProperty("seo_title", NullValueHandling = NullValueHandling.Ignore)]
        public string SeoTitle { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("meta_title")]
        public string MetaTitle { get; set; }

        [JsonProperty("meta_description")]
        public string MetaDescription { get; set; }

        [JsonProperty("meta_keywords")]
        public string MetaKeywords { get; set; }

        [JsonProperty("left", NullValueHandling = NullValueHandling.Ignore)]
        public long? Left { get; set; }

        [JsonProperty("right", NullValueHandling = NullValueHandling.Ignore)]
        public long? Right { get; set; }
        [JsonProperty("position", NullValueHandling = NullValueHandling.Ignore)]
        public long? Position { get; set; }
        [JsonProperty("depth")]
        public long? Depth { get; set; }

        [JsonProperty("updated_at", NullValueHandling = NullValueHandling.Ignore)]
        public DateTimeOffset? UpdatedAt { get; set; }

        [JsonProperty("is_root", NullValueHandling = NullValueHandling.Ignore)]
        public bool? IsRoot { get; set; }

        [JsonProperty("is_child", NullValueHandling = NullValueHandling.Ignore)]
        public bool? IsChild { get; set; }

        [JsonProperty("is_leaf", NullValueHandling = NullValueHandling.Ignore)]
        public bool? IsLeaf { get; set; }
    }
}
