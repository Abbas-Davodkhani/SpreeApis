using Newtonsoft.Json;
using SpreeModel;

namespace SpreeApis.Domain
{
    public class SpreeProduct
    {
        public long SpreeProductId { get; set; }
        public long Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("available_on")]
        public DateTimeOffset AvailableOn { get; set; }

        [JsonProperty("slug")]
        public string Slug { get; set; }

        [JsonProperty("meta_description")]
        public string MetaDescription { get; set; }

        [JsonProperty("meta_keywords")]
        public string MetaKeywords { get; set; }

        [JsonProperty("updated_at")]
        public DateTimeOffset UpdatedAt { get; set; }

        [JsonProperty("sku")]
        public string Sku { get; set; }

        [JsonProperty("public_metadata")]
        public PublicMetadata PublicMetadata { get; set; }

        [JsonProperty("purchasable")]
        public bool Purchasable { get; set; }

        [JsonProperty("in_stock")]
        public bool InStock { get; set; }

        [JsonProperty("backorderable")]
        public bool Backorderable { get; set; }

        [JsonProperty("available")]
        public bool Available { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("price")]
        public string Price { get; set; }

        [JsonProperty("display_price")]
        public string DisplayPrice { get; set; }

        [JsonProperty("compare_at_price")]
        public string CompareAtPrice { get; set; }

        [JsonProperty("display_compare_at_price")]
        public string DisplayCompareAtPrice { get; set; }
        //public ICollection<SpreeProductVariant> SpreeProductVariants { get; set; }  
    }
}
