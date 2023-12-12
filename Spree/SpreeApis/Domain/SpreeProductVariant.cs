namespace SpreeApis.Domain
{
    public class SpreeProductVariant
    {
        public long SpreeProductVariantId { get; set; }
        public long? SpreeProductId { get; set; }
        public long? SpreeVariantId { get; set; }
        public bool IsPrimary { get; set; } 
        public bool IsDefault { get; set; } 
    }
}
