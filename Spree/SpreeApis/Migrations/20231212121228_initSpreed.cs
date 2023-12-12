using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SpreeApis.Migrations
{
    /// <inheritdoc />
    public partial class initSpreed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PublicMetadata",
                columns: table => new
                {
                    PublicMetaDataId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JsonData = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PublicMetadata", x => x.PublicMetaDataId);
                });

            migrationBuilder.CreateTable(
                name: "spree_images",
                columns: table => new
                {
                    SpreeImageId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    TransformedUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Position = table.Column<long>(type: "bigint", nullable: true),
                    Alt = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OriginalUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_spree_images", x => x.SpreeImageId);
                });

            migrationBuilder.CreateTable(
                name: "spree_option_types",
                columns: table => new
                {
                    SpreeOptionTypeId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Presentation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Position = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_spree_option_types", x => x.SpreeOptionTypeId);
                });

            migrationBuilder.CreateTable(
                name: "spree_product_images",
                columns: table => new
                {
                    SpreeProductImageId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SpreeProductId = table.Column<long>(type: "bigint", nullable: false),
                    SpreeTmageId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_spree_product_images", x => x.SpreeProductImageId);
                });

            migrationBuilder.CreateTable(
                name: "spree_product_otionTypes",
                columns: table => new
                {
                    SpreeProductOptionTypeId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SpreeProductId = table.Column<long>(type: "bigint", nullable: false),
                    SpreeOptionTypeId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_spree_product_otionTypes", x => x.SpreeProductOptionTypeId);
                });

            migrationBuilder.CreateTable(
                name: "spree_product_properties",
                columns: table => new
                {
                    SpreeProductPropertyId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SpreeProductId = table.Column<long>(type: "bigint", nullable: false),
                    SpreePropertyId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_spree_product_properties", x => x.SpreeProductPropertyId);
                });

            migrationBuilder.CreateTable(
                name: "spree_product_taxons",
                columns: table => new
                {
                    SpreeProductTaxonId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SpreeProductId = table.Column<long>(type: "bigint", nullable: false),
                    SpreeTaxonId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_spree_product_taxons", x => x.SpreeProductTaxonId);
                });

            migrationBuilder.CreateTable(
                name: "spree_product_variants",
                columns: table => new
                {
                    SpreeProductVariantId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SpreeProductId = table.Column<long>(type: "bigint", nullable: true),
                    SpreeVariantId = table.Column<long>(type: "bigint", nullable: true),
                    IsPrimary = table.Column<bool>(type: "bit", nullable: false),
                    IsDefault = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_spree_product_variants", x => x.SpreeProductVariantId);
                });

            migrationBuilder.CreateTable(
                name: "spree_properties",
                columns: table => new
                {
                    SpreePropertyId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FilterParam = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_spree_properties", x => x.SpreePropertyId);
                });

            migrationBuilder.CreateTable(
                name: "spree_taxons",
                columns: table => new
                {
                    SpreeTaxonId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrettyName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Permalink = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SeoTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MetaTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MetaDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MetaKeywords = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Left = table.Column<long>(type: "bigint", nullable: true),
                    Right = table.Column<long>(type: "bigint", nullable: true),
                    Position = table.Column<long>(type: "bigint", nullable: true),
                    Depth = table.Column<long>(type: "bigint", nullable: true),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsRoot = table.Column<bool>(type: "bit", nullable: true),
                    IsChild = table.Column<bool>(type: "bit", nullable: true),
                    IsLeaf = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_spree_taxons", x => x.SpreeTaxonId);
                });

            migrationBuilder.CreateTable(
                name: "spree_products",
                columns: table => new
                {
                    SpreeProductId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AvailableOn = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    Slug = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MetaDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MetaKeywords = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    Sku = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PublicMetaDataId = table.Column<long>(type: "bigint", nullable: true),
                    Purchasable = table.Column<bool>(type: "bit", nullable: false),
                    InStock = table.Column<bool>(type: "bit", nullable: false),
                    Backorderable = table.Column<bool>(type: "bit", nullable: false),
                    Available = table.Column<bool>(type: "bit", nullable: false),
                    Currency = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DisplayPrice = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompareAtPrice = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DisplayCompareAtPrice = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_spree_products", x => x.SpreeProductId);
                    table.ForeignKey(
                        name: "FK_spree_products_PublicMetadata_PublicMetaDataId",
                        column: x => x.PublicMetaDataId,
                        principalTable: "PublicMetadata",
                        principalColumn: "PublicMetaDataId");
                });

            migrationBuilder.CreateTable(
                name: "spree_variants",
                columns: table => new
                {
                    SpreeVariantId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    Sku = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Weight = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Height = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Width = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Depth = table.Column<long>(type: "bigint", nullable: true),
                    IsMaster = table.Column<bool>(type: "bit", nullable: true),
                    OptionsText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PublicMetaDataId = table.Column<long>(type: "bigint", nullable: true),
                    Purchasable = table.Column<bool>(type: "bit", nullable: true),
                    InStock = table.Column<bool>(type: "bit", nullable: true),
                    Backorderable = table.Column<bool>(type: "bit", nullable: true),
                    Currency = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DisplayPrice = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompareAtPrice = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DisplayCompareAtPrice = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_spree_variants", x => x.SpreeVariantId);
                    table.ForeignKey(
                        name: "FK_spree_variants_PublicMetadata_PublicMetaDataId",
                        column: x => x.PublicMetaDataId,
                        principalTable: "PublicMetadata",
                        principalColumn: "PublicMetaDataId");
                });

            migrationBuilder.CreateTable(
                name: "spree_styles",
                columns: table => new
                {
                    SpreeStyleId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SpreeImageId = table.Column<long>(type: "bigint", nullable: true),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Size = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Width = table.Column<long>(type: "bigint", nullable: false),
                    Height = table.Column<long>(type: "bigint", nullable: false),
                    ImageId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_spree_styles", x => x.SpreeStyleId);
                    table.ForeignKey(
                        name: "FK_spree_styles_spree_images_SpreeImageId",
                        column: x => x.SpreeImageId,
                        principalTable: "spree_images",
                        principalColumn: "SpreeImageId");
                });

            migrationBuilder.CreateTable(
                name: "spree_option_values",
                columns: table => new
                {
                    SpreeOptionValueId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Presentation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Position = table.Column<long>(type: "bigint", nullable: true),
                    SpreeOptionTypeId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_spree_option_values", x => x.SpreeOptionValueId);
                    table.ForeignKey(
                        name: "FK_spree_option_values_spree_option_types_SpreeOptionTypeId",
                        column: x => x.SpreeOptionTypeId,
                        principalTable: "spree_option_types",
                        principalColumn: "SpreeOptionTypeId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_spree_option_values_SpreeOptionTypeId",
                table: "spree_option_values",
                column: "SpreeOptionTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_spree_products_PublicMetaDataId",
                table: "spree_products",
                column: "PublicMetaDataId");

            migrationBuilder.CreateIndex(
                name: "IX_spree_styles_SpreeImageId",
                table: "spree_styles",
                column: "SpreeImageId");

            migrationBuilder.CreateIndex(
                name: "IX_spree_variants_PublicMetaDataId",
                table: "spree_variants",
                column: "PublicMetaDataId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "spree_option_values");

            migrationBuilder.DropTable(
                name: "spree_product_images");

            migrationBuilder.DropTable(
                name: "spree_product_otionTypes");

            migrationBuilder.DropTable(
                name: "spree_product_properties");

            migrationBuilder.DropTable(
                name: "spree_product_taxons");

            migrationBuilder.DropTable(
                name: "spree_product_variants");

            migrationBuilder.DropTable(
                name: "spree_products");

            migrationBuilder.DropTable(
                name: "spree_properties");

            migrationBuilder.DropTable(
                name: "spree_styles");

            migrationBuilder.DropTable(
                name: "spree_taxons");

            migrationBuilder.DropTable(
                name: "spree_variants");

            migrationBuilder.DropTable(
                name: "spree_option_types");

            migrationBuilder.DropTable(
                name: "spree_images");

            migrationBuilder.DropTable(
                name: "PublicMetadata");
        }
    }
}
