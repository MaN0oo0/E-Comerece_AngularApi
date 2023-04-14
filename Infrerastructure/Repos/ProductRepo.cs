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

           return await db.Products
                .Include(a => a.productType)
                .Include(a => a.productBrand)
                .FirstOrDefaultAsync(a => a.Id == Id);
           



        }

        public async Task<IReadOnlyList<Product>> GetProductsAsync()
        {
             return await db.Products
                .Include(a=>a.productBrand)
                .Include(a=>a.productType)
                .ToListAsync();
            
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
