using Core.Entites;
using Core.Interfaces;
using Infrerastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrerastructure.Repos
{
    public class ProductRepo : IProduct
    {
        private readonly StoreContext db;

        public ProductRepo(StoreContext db)
        {
            this.db = db;
        }

        public async Task<Product> GetProductByIdAsync(int Id)
        {

            var data = await db.Products.FindAsync(Id);

            return data;



        }

        public async Task<IReadOnlyList<Product>> GetProductsAsync()
        {
            var data = await db.Products.ToListAsync();
            return data;
        }

        public async Task<IReadOnlyList<ProductBrand>> GetProductsBrandAsync()
        {
          return await db.ProductBrands.ToListAsync();
        }

        public async Task<IReadOnlyList<ProductType>> GetProductsTypeAsync()
        {
            return await db.ProductTypes.ToListAsync();
        }
    }
}
