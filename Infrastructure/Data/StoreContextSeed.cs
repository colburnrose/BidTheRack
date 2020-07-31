using Core.Entities;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Logging;
using System.Text.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class StoreContextSeed
    {
        public static async Task SeedAsync(StoreContext context, ILoggerFactory loggerFactory)
        {
            try
            {
                using(var transaction = context.Database.BeginTransaction())
                {

                    if (!context.ProductBrands.Any())
                    {
                        var data = File.ReadAllText("../Infrastructure/Data/SeedData/brands.json");
                        var brands = JsonSerializer.Deserialize<List<ProductBrand>>(data);

                        foreach (var item in brands)
                        {
                            context.ProductBrands.Add(item);
                        };
                        transaction.Commit();
                    }
                    if (!context.ProductTypes.Any())
                    {
                        var data = File.ReadAllText("../Infrastructure/Data/SeedData/types.json");
                        var product_types = JsonSerializer.Deserialize<List<ProductType>>(data);

                        foreach (var item in product_types)
                        {
                            context.ProductTypes.Add(item);
                        }
                        await context.SaveChangesAsync();
                        transaction.Commit();
                    }
                    if (!context.Products.Any())
                    {
                        var data = File.ReadAllText("../Infrastructure/Data/SeedData/products.json");
                        var products = JsonSerializer.Deserialize<List<Product>>(data);

                        foreach (var item in products)
                        {
                            context.Products.Add(item);
                        }
                        await context.SaveChangesAsync();
                        transaction.Commit();
                    }
                }
                
            }
            catch(Exception ex)
            {
                var logger = loggerFactory.CreateLogger<StoreContextSeed>();
                logger.LogError(ex.Message);
            }
        }
    }
}
