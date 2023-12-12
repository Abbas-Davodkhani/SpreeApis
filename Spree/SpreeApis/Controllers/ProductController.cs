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

            List<SpreeProductVariant> spreeProductVariants = new(); 
            List<SpreeProductProperty> spreeProductProperties= new(); 
            List<SpreeProductOptionType> spreeProductOptionTypes = new(); 
            List<SpreeProductImage> spreeProductImages = new(); 
            List<SpreeProductTaxon> spreeProductTaxons = new(); 

            // product
            foreach (var item in result.Data)
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
                    PublicMetadata = item.Attributes.PublicMetadata,
                    Sku = item.Attributes.Sku,
                    Slug = item.Attributes.Slug,
                    UpdatedAt = item.Attributes.UpdatedAt,
                };

                dbContext.Entry(spreeProduct).State = EntityState.Added;
                await dbContext.SaveChangesAsync();


                foreach (var varinat in item.Relationships.Variants.Data)
                {
                    var spreeVariantModel = new SpreeProductVariant
                    {
                        IsDefault = false,
                        SpreeProductId = spreeProduct.Id,
                        IsPrimary = false,
                        SpreeVariantId = varinat.Id
                    };

                    spreeProductVariants.Add(spreeVariantModel);
                }

                foreach (var property in item.Relationships.ProductProperties.Data)
                {
                    var spreePropertyModel = new SpreeProductProperty
                    {
                        SpreeProductId = spreeProduct.Id,
                        SpreePropertyId = property.Id
                    };
                    spreeProductProperties.Add(spreePropertyModel); 
                }

                foreach (var otionType in item.Relationships.OptionTypes.Data)
                {
                    var spreeariantModel = new SpreeProductOptionType
                    {
                        SpreeProductId = spreeProduct.Id,
                        SpreeOptionTypeId = otionType.Id
                    };

                    spreeProductOptionTypes.Add(spreeariantModel);
                }

                foreach (var image in item.Relationships.Images.Data)
                {
                    var spreeImageModel = new SpreeProductImage
                    {
                        SpreeProductId = spreeProduct.Id,
                        SpreeTmageId = image.Id,
                    };
                    spreeProductImages.Add(spreeImageModel);
                }

                foreach (var taxon in item.Relationships.Taxons.Data)
                {
                    var spreeTaxonModel = new SpreeProductTaxon
                    {
                        SpreeProductId = spreeProduct.Id,
                        SpreeTaxonId = taxon.Id,
                    };
                    spreeProductTaxons.Add(spreeTaxonModel);
                }

                if(spreeProductVariants != null && spreeProductVariants.Any())
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

                if(item.Relationships.DefaultVariant.Data != null)
                {
                    var v = await dbContext.SpreeProductVariants.FirstOrDefaultAsync(x => x.SpreeProductId == spreeProduct.Id && x.SpreeVariantId == item.Relationships.DefaultVariant.Data.Id);
                    if (v == null)
                    {
                        var spreeVariantModel = new SpreeProductVariant
                        {
                            IsDefault = true,
                            SpreeProductId = spreeProduct.Id,
                            IsPrimary = false,
                            SpreeVariantId = item.Relationships.DefaultVariant.Data.Id
                        };
                        spreeProductVariants.Add(spreeVariantModel);
                    }
                    else
                    {
                        v.IsDefault = true;
                        dbContext.SpreeProductVariants.Update(v);
                        await dbContext.SaveChangesAsync();
                    }

                    if (spreeProductVariants != null && spreeProductVariants.Any())
                    {
                        await dbContext.AddRangeAsync(spreeProductVariants);
                        await dbContext.SaveChangesAsync();
                        spreeProductVariants.Clear();
                    }
                }





                if (item.Relationships.PrimaryVariant.Data != null)
                {
                    var v = await dbContext.SpreeProductVariants.FirstOrDefaultAsync(x => x.SpreeProductId == spreeProduct.Id && x.SpreeVariantId == item.Relationships.PrimaryVariant.Data.Id);
                    if (v == null)
                    {
                        var spreeVariantModel = new SpreeProductVariant
                        {
                            IsDefault = false,
                            SpreeProductId = spreeProduct.Id,
                            IsPrimary = true,
                            SpreeVariantId = item.Relationships.PrimaryVariant.Data.Id
                        };
                        spreeProductVariants.Add(spreeVariantModel);
                    }
                    else
                    {
                        v.IsPrimary = true;
                        dbContext.SpreeProductVariants.Update(v);
                        await dbContext.SaveChangesAsync();
                    }

                }

                if (spreeProductVariants != null && spreeProductVariants.Any())
                {
                    await dbContext.AddRangeAsync(spreeProductVariants);
                    await dbContext.SaveChangesAsync();
                    spreeProductVariants.Clear();
                }

            }

            foreach (var item in result.Included.Where(x => x.Type == "variant"))
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
                    PublicMetadata = item.Attributes?.PublicMetadata,
                    Purchasable = item.Attributes?.Purchasable,
                    Sku = item.Attributes?.Sku,
                    Weight = item.Attributes?.Weight,
                    Width = item.Attributes?.Width,
                };

                dbContext.Entry(variantModel).State = EntityState.Added;
                await dbContext.SaveChangesAsync();
            }

            foreach (var item in result.Included.Where(x => x.Type == "option_type"))
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

            foreach (var item in result.Included.Where(x => x.Type == "product_property"))
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

            foreach (var item in result.Included.Where(x => x.Type == "taxon"))
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

                dbContext.Entry(taxonModel).State = EntityState.Added;
                await dbContext.SaveChangesAsync();
            }

            foreach (var item in result.Included.Where(x => x.Type == "image"))
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
                        ImageId = imageModel.Id,
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

        }

    }





}
