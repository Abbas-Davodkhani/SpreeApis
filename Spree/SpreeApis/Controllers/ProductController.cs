using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using SpreeApis.Domain;
using SpreeModel;

namespace SpreeApis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        [HttpGet]
        public async Task Get()
        {
            SpreeDbContext dbContext = new SpreeDbContext();
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get, "/api/v2/storefront/products?page=1&per_page=3&include=default_variant,variants,option_types,product_properties,taxons,images,primary_variant&filter[taxons]=10673");
            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            string res = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<Temperatures>(res);

            #region Product
            List<SpreeProductVariant> spreeProductVariants = new();
            List<SpreeProductProperty> spreeProductProperties = new();
            List<SpreeProductOptionType> spreeProductOptionTypes = new();
            List<SpreeProductImage> spreeProductImages = new();
            List<SpreeProductTaxon> spreeProductTaxons = new();
            // product
            foreach (var item in result.Data)
            {
                if (!await dbContext.SpreeProducts.AnyAsync(x => x.Id == item.Id))
                {
                    var spreeProduct = new SpreeProduct
                    {
                        Id = item.Id,
                        Name = item.Attributes.Name,
                        Available = item.Attributes.Available,
                        AvailableOn = item.Attributes.AvailableOn,
                        Backorderable = item.Attributes.Backorderable,
                        CompareAtPrice = item.Attributes.CompareAtPrice,
                        Currency = item.Attributes.Currency,
                        Description = item.Attributes.Description,
                        DisplayCompareAtPrice = item.Attributes.DisplayCompareAtPrice,
                        DisplayPrice = item.Attributes.DisplayPrice,
                        InStock = item.Attributes.InStock,
                        MetaDescription = item.Attributes.MetaDescription,
                        MetaKeywords = item.Attributes.MetaKeywords,
                        Price = item.Attributes.Price,
                        Purchasable = item.Attributes.Purchasable,
                        //PublicMetadata = item.Attributes.PublicMetadata,
                        Sku = item.Attributes.Sku,
                        Slug = item.Attributes.Slug,
                        UpdatedAt = item.Attributes.UpdatedAt,
                    };

                    dbContext.Entry(spreeProduct).State = EntityState.Added;
                    await dbContext.SaveChangesAsync();

                }

                foreach (var varinat in item.Relationships.Variants.Data)
                {
                    if (!await dbContext.SpreeProductVariants.AnyAsync(x => x.SpreeProductId == item.Id && x.SpreeVariantId == varinat.Id))
                    {
                        var spreeVariantModel = new SpreeProductVariant
                        {
                            IsDefault = false,
                            SpreeProductId = item.Id,
                            IsPrimary = false,
                            SpreeVariantId = varinat.Id
                        };

                        spreeProductVariants.Add(spreeVariantModel);
                    }
                }

                foreach (var property in item.Relationships.ProductProperties.Data)
                {
                    if (!await dbContext.SpreeProductProperties.AnyAsync(x => x.SpreeProductId == item.Id && x.SpreePropertyId == property.Id))
                    {
                        var spreePropertyModel = new SpreeProductProperty
                        {
                            SpreeProductId = item.Id,
                            SpreePropertyId = property.Id
                        };
                        spreeProductProperties.Add(spreePropertyModel);
                    }
                }

                foreach (var optionType in item.Relationships.OptionTypes.Data)
                {
                    if (!await dbContext.SpreeProductOptionTypes.AnyAsync(x => x.SpreeProductId == item.Id && x.SpreeOptionTypeId == optionType.Id))
                    {
                        var spreeariantModel = new SpreeProductOptionType
                        {
                            SpreeProductId = item.Id,
                            SpreeOptionTypeId = optionType.Id
                        };

                        spreeProductOptionTypes.Add(spreeariantModel);
                    }
                }

                foreach (var image in item.Relationships.Images.Data)
                {
                    if (!await dbContext.SpreeProductImages.AnyAsync(x => x.SpreeProductId == item.Id && x.SpreeImageId == image.Id))
                    {
                        var spreeImageModel = new SpreeProductImage
                        {
                            SpreeProductId = item.Id,
                            SpreeImageId = image.Id,
                        };
                        spreeProductImages.Add(spreeImageModel);
                    }
                }

                foreach (var taxon in item.Relationships.Taxons.Data)
                {
                    if (!await dbContext.SpreeProductTaxons.AnyAsync(x => x.SpreeProductId == item.Id && x.SpreeTaxonId == taxon.Id))
                    {
                        var spreeTaxonModel = new SpreeProductTaxon
                        {
                            SpreeProductId = item.Id,
                            SpreeTaxonId = taxon.Id,
                        };
                        spreeProductTaxons.Add(spreeTaxonModel);
                    }
                }

                if (item.Relationships.DefaultVariant.Data != null)
                {
                    var v = spreeProductVariants.FirstOrDefault(x => x.SpreeProductId == item.Id && x.SpreeVariantId == item.Relationships.DefaultVariant.Data.Id);
                    if (v is null)
                    {
                        if (!await dbContext.SpreeProductVariants.AnyAsync(x => x.SpreeProductId == item.Id && x.SpreeVariantId == item.Relationships.DefaultVariant.Data.Id && x.IsDefault))
                        {
                            var spreeVariantModel = new SpreeProductVariant
                            {
                                IsDefault = true,
                                SpreeProductId = item.Id,
                                SpreeVariantId = item.Relationships.DefaultVariant.Data.Id
                            };
                            spreeProductVariants.Add(spreeVariantModel);
                        }
                    }
                    else
                    {
                        v.IsDefault = true;
                    }
                }

                if (item.Relationships.PrimaryVariant.Data != null)
                {
                    var v = spreeProductVariants.FirstOrDefault(x => x.SpreeProductId == item.Id && x.SpreeVariantId == item.Relationships.PrimaryVariant.Data.Id);
                    if (v is null)
                    {
                        if (!await dbContext.SpreeProductVariants.AnyAsync(x => x.SpreeProductId == item.Id && x.SpreeVariantId == item.Relationships.DefaultVariant.Data.Id && x.IsPrimary))
                        {
                            var spreeVariantModel = new SpreeProductVariant
                            {
                                SpreeProductId = item.Id,
                                IsPrimary = true,
                                SpreeVariantId = item.Relationships.PrimaryVariant.Data.Id
                            };
                            spreeProductVariants.Add(spreeVariantModel);
                        }
                    }
                    else
                    {
                        v.IsPrimary = true;
                    }

                }
            }
            if (spreeProductVariants != null && spreeProductVariants.Any())
                await dbContext.AddRangeAsync(spreeProductVariants);
            if (spreeProductProperties != null && spreeProductProperties.Any())
                await dbContext.AddRangeAsync(spreeProductProperties);
            if (spreeProductOptionTypes != null && spreeProductOptionTypes.Any())
                await dbContext.AddRangeAsync(spreeProductOptionTypes);
            if (spreeProductImages != null && spreeProductImages.Any())
                await dbContext.AddRangeAsync(spreeProductImages);
            if (spreeProductTaxons != null && spreeProductTaxons.Any())
                await dbContext.AddRangeAsync(spreeProductTaxons);

            await dbContext.SaveChangesAsync();

            spreeProductVariants.Clear();
            spreeProductProperties.Clear();
            spreeProductOptionTypes.Clear();
            spreeProductImages.Clear();
            spreeProductTaxons.Clear();
            #endregion

            #region Variant
            // vairant
            List<SpreeVariantImage> spreeVariantImages = new();
            List<SpreeVariantOptionValue> spreeVariantOptionValues = new();
            foreach (var item in result.Included.Where(x => x.Type == "variant"))
            {
                if (!await dbContext.SpreeVariants.AnyAsync(x => x.Id == item.Id))
                {
                    var variantModel = new SpreeVariant
                    {
                        Id = item.Id,
                        Backorderable = item.Attributes?.Backorderable,
                        CompareAtPrice = item.Attributes?.CompareAtPrice,
                        Currency = item.Attributes?.Currency,
                        Depth = item.Attributes?.Depth,
                        DisplayCompareAtPrice = item.Attributes?.DisplayCompareAtPrice,
                        DisplayPrice = item.Attributes?.DisplayPrice,
                        Height = item.Attributes?.Height,
                        InStock = item.Attributes?.InStock,
                        IsMaster = item.Attributes?.IsMaster,
                        OptionsText = item.Attributes?.OptionsText,
                        Price = item.Attributes?.Price,
                        //PublicMetadata = item.Attributes?.PublicMetadata,
                        Purchasable = item.Attributes?.Purchasable,
                        Sku = item.Attributes?.Sku,
                        Weight = item.Attributes?.Weight,
                        Width = item.Attributes?.Width,
                    };

                    dbContext.Entry(variantModel).State = EntityState.Added;
                    await dbContext.SaveChangesAsync();
                }

                foreach (var image in item.Relationships.Images.Data)
                {
                    if (!await dbContext.SpreeVariantImages.AnyAsync(x => x.SpreeVariantId == item.Id && x.SpreeImageId == image.Id))
                    {
                        SpreeVariantImage spreeVariantImage = new()
                        {
                            SpreeVariantId = item.Id,
                            SpreeImageId = image.Id,
                        };
                        spreeVariantImages.Add(spreeVariantImage);
                    }
                }

                foreach (var optionValue in item.Relationships.OptionValues.Data)
                {
                    if (!await dbContext.SpreeVariantOptionValues.AnyAsync(x => x.SpreeVariantId == item.Id && x.SpreeOptionValueId == optionValue.Id))
                    {
                        SpreeVariantOptionValue spreeVariantOptionValue = new()
                        {
                            SpreeVariantId = item.Id,
                            SpreeOptionValueId = optionValue.Id,
                        };
                        spreeVariantOptionValues.Add(spreeVariantOptionValue);
                    }
                }
            }

            if (spreeVariantImages != null && spreeVariantImages.Any())
                await dbContext.AddRangeAsync(spreeVariantImages);
            if (spreeVariantOptionValues != null && spreeVariantOptionValues.Any())
                await dbContext.AddRangeAsync(spreeVariantOptionValues);

            await dbContext.SaveChangesAsync();
            spreeVariantImages.Clear();
            spreeVariantOptionValues.Clear();
            #endregion

            #region OptionType
            // optionType
            List<SpreeOptionTypeOptionValue> spreeOptionTypeOptionValues = new();
            foreach (var item in result.Included.Where(x => x.Type == "option_type"))
            {
                if (!await dbContext.SpreeOptionTypes.AnyAsync(x => x.Id == item.Id))
                {
                    var optionTypeModel = new SpreeOptionType
                    {
                        Id = item.Id,
                        Name = item.Attributes.Name,
                        Position = item.Attributes.Position,
                        Presentation = item.Attributes?.Presentation,
                    };

                    dbContext.Entry(optionTypeModel).State = EntityState.Added;
                    await dbContext.SaveChangesAsync();
                }

                foreach (var optionValue in item.Relationships.OptionValues.Data)
                {
                    if (!await dbContext.SpreeOptionTypeOptionValues.AnyAsync(x => x.SpreeOptionTypeId == item.Id && x.SpreeOptionValueId == optionValue.Id))
                    {
                        SpreeOptionTypeOptionValue spreeOptionTypeOptionValue = new()
                        {
                            SpreeOptionTypeId = item.Id,
                            SpreeOptionValueId = optionValue.Id,
                        };
                        spreeOptionTypeOptionValues.Add(spreeOptionTypeOptionValue);
                    }
                }
            }
            if (spreeOptionTypeOptionValues != null && spreeOptionTypeOptionValues.Any())
                await dbContext.AddRangeAsync(spreeOptionTypeOptionValues);

            await dbContext.SaveChangesAsync();
            spreeOptionTypeOptionValues.Clear();
            #endregion

            #region ProductProperty
            // product property
            foreach (var item in result.Included.Where(x => x.Type == "product_property"))
            {
                if (!await dbContext.SpreeProperties.AnyAsync(x => x.Id == item.Id))
                {
                    var propertyModel = new SpreeProperty
                    {
                        Id = item.Id,
                        Name = item?.Attributes.Name,
                        Description = item.Attributes?.Description,
                        FilterParam = item.Attributes?.FilterParam,
                        Value = item.Attributes?.Value,
                    };

                    dbContext.Entry(propertyModel).State = EntityState.Added;
                    await dbContext.SaveChangesAsync();
                }
            }
            #endregion

            #region Taxon
            // taxon
            List<SpreeTaxonChildren> spreeTaxonChildrens = new();
            List<SpreeTaxonImage> spreeTaxonImages = new();
            foreach (var item in result.Included.Where(x => x.Type == "taxon"))
            {
                if (!await dbContext.SpreeTaxons.AnyAsync(x => x.Id == item.Id))
                {
                    var taxonModel = new SpreeTaxon
                    {
                        Id = item.Id,
                        Description = item.Attributes?.Description,
                        Name = item.Attributes?.Name,
                        Depth = item.Attributes?.Depth,
                        IsChild = item.Attributes?.IsChild,
                        IsLeaf = item.Attributes?.IsLeaf,
                        IsRoot = item.Attributes?.IsRoot,
                        Left = item.Attributes?.Left,
                        MetaDescription = item.Attributes?.MetaDescription,
                        MetaKeywords = item.Attributes?.MetaKeywords,
                        MetaTitle = item.Attributes?.MetaTitle,
                        Permalink = item.Attributes?.Permalink,
                        Position = item.Attributes?.Position,
                        PrettyName = item.Attributes?.PrettyName,
                        Right = item.Attributes?.Right,
                        SeoTitle = item.Attributes?.SeoTitle,
                        UpdatedAt = item.Attributes?.UpdatedAt
                    };

                    var taxonomyId = item.Relationships.Taxonomy.Data?.Id;
                    var parentId = item.Relationships.Parent.Data?.Id;

                    taxonModel.TaxonomyId = taxonomyId;
                    taxonModel.ParentId = parentId;

                    dbContext.Entry(taxonModel).State = EntityState.Added;
                    await dbContext.SaveChangesAsync();
                }


                foreach (var child in item.Relationships.Children.Data)
                {
                    if (!await dbContext.SpreeTaxonChildrens.AnyAsync(x => x.SpreeSupTaxonId == item.Id && x.SpreeSubTaxonId == child.Id))
                    {
                        SpreeTaxonChildren spreeTaxonChildren = new()
                        {
                            SpreeSupTaxonId = item.Id,
                            SpreeSubTaxonId = child.Id,
                        };
                        spreeTaxonChildrens.Add(spreeTaxonChildren);
                    }
                }

                foreach (var image in item.Relationships.Images.Data)
                {
                    if (!await dbContext.SpreeTaxonImages.AnyAsync(x => x.SpreeTaxonId == item.Id && x.SpreeImageId == image.Id))
                    {
                        SpreeTaxonImage spreeTaxonImage = new()
                        {
                            SpreeImageId = image.Id,
                            SpreeTaxonId = item.Id
                        };
                        spreeTaxonImages.Add(spreeTaxonImage);
                    }
                }
            }

            if (spreeTaxonChildrens != null && spreeTaxonChildrens.Any())
                await dbContext.AddRangeAsync(spreeTaxonChildrens);
            if (spreeTaxonImages != null && spreeTaxonImages.Any())
                await dbContext.AddRangeAsync(spreeTaxonImages);

            await dbContext.SaveChangesAsync();
            spreeTaxonChildrens.Clear();
            #endregion

            #region Image
            // image
            foreach (var item in result.Included.Where(x => x.Type == "image"))
            {
                SpreeImage spreeImage = await dbContext.SpreeImages.FirstOrDefaultAsync(x => x.Id == item.Id);
                if (spreeImage is null)
                {
                    var imageModel = new SpreeImage
                    {
                        Id = item.Id,
                        Alt = item.Attributes?.Alt,
                        OriginalUrl = item.Attributes?.OriginalUrl,
                        Position = item.Attributes?.Position,
                        TransformedUrl = item.Attributes?.TransformedUrl,
                    };

                    dbContext.Entry(imageModel).State = EntityState.Added;
                    await dbContext.SaveChangesAsync();
                    foreach (var style in item.Attributes.Styles)
                    {
                        var styleModel = new SpreeStyle
                        {
                            ImageId = item.Id,
                            SpreeImageId = imageModel.SpreeImageId,
                            Height = style.Height,
                            Size = style.Size,
                            Url = style.Url,
                            Width = style.Width,
                        };

                        dbContext.Entry(styleModel).State = EntityState.Added;
                        await dbContext.SaveChangesAsync();
                    }
                }
                else
                {
                    foreach (var style in item.Attributes.Styles)
                    {
                        if (!await dbContext.SpreeStyles.AnyAsync(x => x.ImageId == item.Id && x.SpreeImageId == spreeImage.Id))
                        {
                            var styleModel = new SpreeStyle
                            {
                                ImageId = item.Id,
                                SpreeImageId = spreeImage.SpreeImageId,
                                Height = style.Height,
                                Size = style.Size,
                                Url = style.Url,
                                Width = style.Width,
                            };

                            dbContext.Entry(styleModel).State = EntityState.Added;
                            await dbContext.SaveChangesAsync();
                        }
                    }
                }


            }
            #endregion

            #region OptionValue
            // option value
            List<SpreeOptionValue> spreeOptionValues = new();
            foreach (var item in result.Meta.Filters.OptionTypes)
            {
                foreach (var optionValue in item.OptionValues)
                {
                    if(!await dbContext.SpreeOptionValues.AnyAsync(x => x.Id == optionValue.Id))
                    {
                        SpreeOptionValue spreeOptionValue = new()
                        {
                            Id = optionValue.Id,
                            Name = optionValue.Name,
                            Position = optionValue.Position,
                            Presentation = optionValue.Presentation,
                        };
                        spreeOptionValues.Add(spreeOptionValue);
                    }
                }
            }

            if (spreeOptionValues != null && spreeOptionValues.Any())
                await dbContext.AddRangeAsync(spreeOptionValues);

            await dbContext.SaveChangesAsync();
            spreeOptionValues.Clear();
            #endregion  
        }
    }
}
