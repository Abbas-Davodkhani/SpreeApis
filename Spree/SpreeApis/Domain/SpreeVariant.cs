using Newtonsoft.Json;
using SpreeModel;

namespace SpreeApis.Domain
{
    public class SpreeVariant
    {
        public long SpreeVariantId { get; set; }
        [JsonProperty("id")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long Id { get; set; }
        [JsonProperty("sku", NullValueHandling = NullValueHandling.Ignore)]
        public string Sku { get; set; }

        [JsonProperty("weight", NullValueHandling = NullValueHandling.Ignore)]
        public string Weight { get; set; }

        [JsonProperty("height")]
        public string Height { get; set; }

        [JsonProperty("width")]
        public string Width { get; set; }

        [JsonProperty("depth")]
        public long? Depth { get; set; }

        [JsonProperty("is_master", NullValueHandling = NullValueHandling.Ignore)]
        public bool? IsMaster { get; set; }

        [JsonProperty("options_text", NullValueHandling = NullValueHandling.Ignore)]
        public string OptionsText { get; set; }

        [JsonProperty("public_metadata", NullValueHandling = NullValueHandling.Ignore)]
        public PublicMetadata? PublicMetadata { get; set; }

        [JsonProperty("purchasable", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Purchasable { get; set; }

        [JsonProperty("in_stock", NullValueHandling = NullValueHandling.Ignore)]
        public bool? InStock { get; set; }

        [JsonProperty("backorderable", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Backorderable { get; set; }

        [JsonProperty("currency", NullValueHandling = NullValueHandling.Ignore)]
        public string Currency { get; set; }

        [JsonProperty("price", NullValueHandling = NullValueHandling.Ignore)]
        public string Price { get; set; }

        [JsonProperty("display_price", NullValueHandling = NullValueHandling.Ignore)]
        public string DisplayPrice { get; set; }

        [JsonProperty("compare_at_price", NullValueHandling = NullValueHandling.Ignore)]
        public string CompareAtPrice { get; set; }

        [JsonProperty("display_compare_at_price", NullValueHandling = NullValueHandling.Ignore)]
        public string DisplayCompareAtPrice { get; set; }

        //public ICollection<SpreeProductVariant> SpreeProductVariants { get; set; }  
    }
}
