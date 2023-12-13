using Microsoft.EntityFrameworkCore;
using SpreeModel;

namespace SpreeApis.Domain
{
    public class SpreeDbContext : DbContext
    {
        public SpreeDbContext()
        {
            //this.Database.EnsureDeleted();
            //this.Database.EnsureCreated();
        }
        public DbSet<PublicMetadata> PublicMetadata { get; set; }
        public DbSet<SpreeOptionType> SpreeOptionTypes { get; set; }
        public DbSet<SpreeOptionValue> SpreeOptionValues { get; set; }
        public DbSet<SpreeProduct> SpreeProducts { get; set; }
        public DbSet<SpreeVariant> SpreeVariants { get; set; }
        public DbSet<SpreeProperty> SpreeProperties { get; set; }
        public DbSet<SpreeTaxon> SpreeTaxons { get; set; }
        public DbSet<SpreeImage> SpreeImages { get; set; }
        public DbSet<SpreeStyle> SpreeStyles { get; set; }
        public DbSet<SpreeProductVariant> SpreeProductVariants { get; set; }
        public DbSet<SpreeProductProperty> SpreeProductProperties { get; set; }
        public DbSet<SpreeProductTaxon> SpreeProductTaxons { get; set; }
        public DbSet<SpreeProductImage> SpreeProductImages { get; set; }
        public DbSet<SpreeProductOptionType> SpreeProductOptionTypes { get; set; }
        public DbSet<SpreeOptionTypeOptionValue> SpreeOptionTypeOptionValues { get; set; }
        public DbSet<SpreeTaxonChildren> SpreeTaxonChildrens { get; set; }
        public DbSet<SpreeTaxonImage> SpreeTaxonImages { get; set; }
        public DbSet<SpreeVariantImage> SpreeVariantImages { get; set; }
        public DbSet<SpreeVariantOptionValue> SpreeVariantOptionValues { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer("Data Source=MINICASE-1-CORE\\SA;Initial Catalog=SpreeDb;Persist Security Info=True; User ID=sa;Password=ARZ0909; MultipleActiveResultSets=true;TrustServerCertificate=True");

            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            ///****************************************************************************
            modelBuilder.Entity<SpreeOptionType>()
                .ToTable("spree_option_types");

            //modelBuilder.Entity<SpreeOptionType>()
            //     .Property(x => x.Id).ValueGeneratedNever();

            modelBuilder.Entity<SpreeOptionType>()
                .HasKey(x => x.SpreeOptionTypeId);

            ///****************************************************************************
            modelBuilder.Entity<SpreeOptionValue>()
               .ToTable("spree_option_values");

            //modelBuilder.Entity<SpreeOptionValue>()
            //   .Property(x => x.Id).ValueGeneratedNever();

            modelBuilder.Entity<SpreeOptionValue>()
               .HasKey(x => x.SpreeOptionValueId);

            ///****************************************************************************
            modelBuilder.Entity<SpreeProduct>()
                .ToTable("spree_products");

            //modelBuilder.Entity<SpreeProduct>()
            //     .Property(x => x.Id).ValueGeneratedNever();

            modelBuilder.Entity<SpreeProduct>()
               .HasKey(x => x.SpreeProductId);
            ///****************************************************************************
            modelBuilder.Entity<SpreeVariant>()
               .ToTable("spree_variants");

            //modelBuilder.Entity<SpreeVariant>()
            //     .Property(x => x.Id).ValueGeneratedNever();

            modelBuilder.Entity<SpreeVariant>()
               .HasKey(x => x.SpreeVariantId);
            ///****************************************************************************
            modelBuilder.Entity<SpreeProperty>()
                .ToTable("spree_properties");

            //modelBuilder.Entity<SpreeProperty>()
            //     .Property(x => x.Id).ValueGeneratedNever();

            modelBuilder.Entity<SpreeProperty>()
               .HasKey(x => x.SpreePropertyId);
            ///****************************************************************************
            modelBuilder.Entity<SpreeTaxon>()
              .ToTable("spree_taxons");

            //modelBuilder.Entity<SpreeTaxon>()
            //   .Property(x => x.Id).ValueGeneratedNever();

            modelBuilder.Entity<SpreeTaxon>()
               .HasKey(x => x.SpreeTaxonId);
            ///****************************************************************************
            modelBuilder.Entity<SpreeImage>()
           .ToTable("spree_images");

            //modelBuilder.Entity<SpreeImage>()
            //     .Property(x => x.Id).ValueGeneratedNever();

            modelBuilder.Entity<SpreeImage>()
               .HasKey(x => x.SpreeImageId);
            ///****************************************************************************
            modelBuilder.Entity<SpreeStyle>()
           .ToTable("spree_styles");

            //modelBuilder.Entity<SpreeStyle>()
            //     .Property(x => x.Id).ValueGeneratedNever();

            modelBuilder.Entity<SpreeStyle>()
                 .HasKey(x => x.SpreeStyleId);
            ///****************************************************************************

            modelBuilder.Entity<SpreeProductVariant>()
                .ToTable("spree_product_variants");

            modelBuilder.Entity<SpreeProductTaxon>()
                .ToTable("spree_product_taxons");

            modelBuilder.Entity<SpreeProductImage>()
                .ToTable("spree_product_images");

            modelBuilder.Entity<SpreeProductOptionType>()
                .ToTable("spree_product_otionTypes");

            modelBuilder.Entity<SpreeProductProperty>()
                .ToTable("spree_product_properties");

            modelBuilder.Entity<SpreeOptionTypeOptionValue>() // 
               .ToTable("spree_optionTypes_optionValues");

            modelBuilder.Entity<SpreeTaxonChildren>()
               .ToTable("spree_taxon_children");

            modelBuilder.Entity<SpreeTaxonImage>()
               .ToTable("spree_taxon_images");

            modelBuilder.Entity<SpreeVariantImage>()
               .ToTable("spree_variant_images");

            modelBuilder.Entity<SpreeVariantOptionValue>()
             .ToTable("spree_variants_optionValues");


            base.OnModelCreating(modelBuilder);
        }
    }
}
