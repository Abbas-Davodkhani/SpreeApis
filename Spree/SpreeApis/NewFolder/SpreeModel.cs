namespace SpreeModel
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class Temperatures
    {
        [JsonProperty("data")]
        public List<Datum> Data { get; set; }

        [JsonProperty("included")]
        public List<Included> Included { get; set; }

        [JsonProperty("meta")]
        public Meta Meta { get; set; }

        [JsonProperty("links")]
        public Links Links { get; set; }
    }


    public partial class Datum
    {
        [JsonProperty("id")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long Id { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("attributes")]
        public DatumAttributes Attributes { get; set; }

        [JsonProperty("relationships")]
        public DatumRelationships Relationships { get; set; }
    }

    public partial class DatumAttributes
    {
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
        public PublicMetadata? PublicMetadata { get; set; }

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
    }

    public partial class PublicMetadata
    {
        public long PublicMetaDataId { get; set; }
        public string? JsonData { get; set; }
    }

    public partial class DatumRelationships
    {
        [JsonProperty("variants")]
        public Images Variants { get; set; }

        [JsonProperty("option_types")]
        public Images OptionTypes { get; set; }

        [JsonProperty("product_properties")]
        public Images ProductProperties { get; set; }

        [JsonProperty("taxons")]
        public Images Taxons { get; set; }

        [JsonProperty("images")]
        public Images Images { get; set; }

        [JsonProperty("default_variant")]
        public DefaultVariant DefaultVariant { get; set; }

        [JsonProperty("primary_variant")]
        public DefaultVariant PrimaryVariant { get; set; }
    }

    public partial class DefaultVariant
    {
        [JsonProperty("data")]
        public Dat Data { get; set; }
    }

    public partial class Dat
    {
        [JsonProperty("id")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long Id { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }
    }

    public partial class Images
    {
        [JsonProperty("data")]
        public List<Dat> Data { get; set; }
    }

    public partial class Included
    {
        [JsonProperty("id")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long Id { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("attributes")]
        public IncludedAttributes Attributes { get; set; }

        [JsonProperty("relationships", NullValueHandling = NullValueHandling.Ignore)]
        public IncludedRelationships Relationships { get; set; }
    }

    public partial class IncludedAttributes
    {
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
        public PublicMetadata PublicMetadata { get; set; }

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

        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        [JsonProperty("presentation", NullValueHandling = NullValueHandling.Ignore)]
        public string Presentation { get; set; }

        [JsonProperty("position", NullValueHandling = NullValueHandling.Ignore)]
        public long? Position { get; set; }

        [JsonProperty("value", NullValueHandling = NullValueHandling.Ignore)]
        public string Value { get; set; }

        [JsonProperty("filter_param", NullValueHandling = NullValueHandling.Ignore)]
        public string FilterParam { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("pretty_name", NullValueHandling = NullValueHandling.Ignore)]
        public string PrettyName { get; set; }

        [JsonProperty("permalink", NullValueHandling = NullValueHandling.Ignore)]
        public string Permalink { get; set; }

        [JsonProperty("seo_title", NullValueHandling = NullValueHandling.Ignore)]
        public string SeoTitle { get; set; }

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

        [JsonProperty("updated_at", NullValueHandling = NullValueHandling.Ignore)]
        public DateTimeOffset? UpdatedAt { get; set; }

        [JsonProperty("is_root", NullValueHandling = NullValueHandling.Ignore)]
        public bool? IsRoot { get; set; }

        [JsonProperty("is_child", NullValueHandling = NullValueHandling.Ignore)]
        public bool? IsChild { get; set; }

        [JsonProperty("is_leaf", NullValueHandling = NullValueHandling.Ignore)]
        public bool? IsLeaf { get; set; }

        [JsonProperty("transformed_url")]
        public string TransformedUrl { get; set; }

        [JsonProperty("styles", NullValueHandling = NullValueHandling.Ignore)]
        public List<Style> Styles { get; set; }

        [JsonProperty("alt", NullValueHandling = NullValueHandling.Ignore)]
        public string Alt { get; set; }

        [JsonProperty("original_url", NullValueHandling = NullValueHandling.Ignore)]
        public string OriginalUrl { get; set; }
    }

    public partial class Style
    {
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
    }

    public partial class IncludedRelationships
    {
        [JsonProperty("product", NullValueHandling = NullValueHandling.Ignore)]
        public DefaultVariant Product { get; set; }

        [JsonProperty("images", NullValueHandling = NullValueHandling.Ignore)]
        public Images Images { get; set; }

        [JsonProperty("option_values", NullValueHandling = NullValueHandling.Ignore)]
        public Images OptionValues { get; set; }

        [JsonProperty("vendor", NullValueHandling = NullValueHandling.Ignore)]
        public DefaultVariant Vendor { get; set; }

        [JsonProperty("parent", NullValueHandling = NullValueHandling.Ignore)]
        public DefaultVariant Parent { get; set; }

        [JsonProperty("taxonomy", NullValueHandling = NullValueHandling.Ignore)]
        public DefaultVariant Taxonomy { get; set; }

        [JsonProperty("children", NullValueHandling = NullValueHandling.Ignore)]
        public Images Children { get; set; }

        [JsonProperty("image", NullValueHandling = NullValueHandling.Ignore)]
        public DefaultVariant Image { get; set; }
    }

    public partial class Links
    {
        [JsonProperty("self")]
        public Uri Self { get; set; }

        [JsonProperty("next")]
        public Uri Next { get; set; }

        [JsonProperty("prev")]
        public Uri Prev { get; set; }

        [JsonProperty("last")]
        public Uri Last { get; set; }

        [JsonProperty("first")]
        public Uri First { get; set; }
    }

    public partial class Meta
    {
        [JsonProperty("count")]
        public long Count { get; set; }

        [JsonProperty("total_count")]
        public long TotalCount { get; set; }

        [JsonProperty("total_pages")]
        public long TotalPages { get; set; }

        [JsonProperty("filters")]
        public Filters Filters { get; set; }
    }

    public partial class Filters
    {
        [JsonProperty("option_types")]
        public List<Option> OptionTypes { get; set; }

        [JsonProperty("product_properties")]
        public List<object> ProductProperties { get; set; }
    }

    public partial class Option
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("presentation")]
        public string Presentation { get; set; }

        [JsonProperty("option_values", NullValueHandling = NullValueHandling.Ignore)]
        public List<Option> OptionValues { get; set; }

        [JsonProperty("position", NullValueHandling = NullValueHandling.Ignore)]
        public long? Position { get; set; }
    }

    public enum TypeEnum { Image, OptionType, OptionValue, Product, ProductProperty, Taxon, TaxonImage, Taxonomy, Variant };

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                TypeEnumConverter.Singleton,
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }

    internal class ParseStringConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(long) || t == typeof(long?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            long l;
            if (Int64.TryParse(value, out l))
            {
                return l;
            }
            throw new Exception("Cannot unmarshal type long");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (long)untypedValue;
            serializer.Serialize(writer, value.ToString());
            return;
        }

        public static readonly ParseStringConverter Singleton = new ParseStringConverter();
    }

    internal class TypeEnumConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(TypeEnum) || t == typeof(TypeEnum?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "image":
                    return TypeEnum.Image;
                case "option_type":
                    return TypeEnum.OptionType;
                case "option_value":
                    return TypeEnum.OptionValue;
                case "product":
                    return TypeEnum.Product;
                case "product_property":
                    return TypeEnum.ProductProperty;
                case "taxon":
                    return TypeEnum.Taxon;
                case "taxon_image":
                    return TypeEnum.TaxonImage;
                case "taxonomy":
                    return TypeEnum.Taxonomy;
                case "variant":
                    return TypeEnum.Variant;
            }
            throw new Exception("Cannot unmarshal type TypeEnum");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (TypeEnum)untypedValue;
            switch (value)
            {
                case TypeEnum.Image:
                    serializer.Serialize(writer, "image");
                    return;
                case TypeEnum.OptionType:
                    serializer.Serialize(writer, "option_type");
                    return;
                case TypeEnum.OptionValue:
                    serializer.Serialize(writer, "option_value");
                    return;
                case TypeEnum.Product:
                    serializer.Serialize(writer, "product");
                    return;
                case TypeEnum.ProductProperty:
                    serializer.Serialize(writer, "product_property");
                    return;
                case TypeEnum.Taxon:
                    serializer.Serialize(writer, "taxon");
                    return;
                case TypeEnum.TaxonImage:
                    serializer.Serialize(writer, "taxon_image");
                    return;
                case TypeEnum.Taxonomy:
                    serializer.Serialize(writer, "taxonomy");
                    return;
                case TypeEnum.Variant:
                    serializer.Serialize(writer, "variant");
                    return;
            }
            throw new Exception("Cannot marshal type TypeEnum");
        }

        public static readonly TypeEnumConverter Singleton = new TypeEnumConverter();
    }
}