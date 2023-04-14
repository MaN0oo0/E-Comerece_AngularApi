using Core.Entites;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Infrerastructure.Data
{
    public class StoreContextSeed
    {
        public static async Task SeedAsync(StoreContext context)
        {


            if (!context.Products.Any())
            {
                var Products = File.ReadAllText("../Infrerastructure/SeedData/products.json");
                var products = JsonSerializer.Deserialize<List<Product>>(Products);
                await context.Products.AddRangeAsync(products);
            }


            if (!context.ProductBrands.Any())
            {
                var brandProduct = File.ReadAllText("../Infrerastructure/SeedData/brands.json");
                var Brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandProduct);
                await context.ProductBrands.AddRangeAsync(Brands);

            }



            if (!context.ProductTypes.Any())
            {
                var typeProducts = File.ReadAllText("../Infrerastructure/SeedData/types.json");
                var Types = JsonSerializer.Deserialize<List<ProductType>>(typeProducts);
                await context.ProductTypes.AddRangeAsync(Types);
            }
            if (context.ChangeTracker.HasChanges()) { await context.SaveChangesAsync(); }
        }
    }
}
