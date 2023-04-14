using Core.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IProduct
    {
        Task<Product> GetProductByIdAsync(int Id);
        Task<IReadOnlyList<Product>> GetProductsAsync();
        Task<IReadOnlyList<ProductBrand>> GetProductsBrandAsync();
        Task<IReadOnlyList<ProductType>> GetProductsTypeAsync();
    }
}
