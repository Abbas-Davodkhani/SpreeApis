namespace SpreeApis.Domain
{
    public class SpreeProductProperty
    {
        public long SpreeProductPropertyId { get; set; }
        public long SpreeProductId { get; set; }    
        public long SpreePropertyId { get; set; }   
    }

    public class SpreeProductTaxon
    {
        public long SpreeProductTaxonId { get; set; }
        public long SpreeProductId { get; set; }
        public long SpreeTaxonId { get; set; }
    }

    public class SpreeProductImage 
    {
        public long SpreeProductImageId { get; set; }
        public long SpreeProductId { get; set; }
        public long SpreeTmageId { get; set; }
    }
    public class SpreeProductOptionType
    {
        public long SpreeProductOptionTypeId { get; set; }
        public long SpreeProductId { get; set; }
        public long SpreeOptionTypeId { get; set; }
    }
}
