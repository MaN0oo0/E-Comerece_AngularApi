using Core.Entites;
using Core.Helpers.ProductHelperParam;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Helpers
{
    public class ProductWithIncludes : Helpers<Product>
    {

        public ProductWithIncludes(ProductHelpParam productHelpParam) : base(x =>

        (
        !productHelpParam.BrandId.HasValue || x.ProductBrandId == productHelpParam.BrandId)
        &&
        (!productHelpParam.TypeId.HasValue || x.ProductTypeId == productHelpParam.TypeId)


        )
        {

            AddIncludes(a => a.productBrand);
            AddIncludes(a => a.productType);
            ApplyPaging((productHelpParam.PageSize * (productHelpParam.PageIndex - 1)), productHelpParam.PageSize);


            if (!string.IsNullOrEmpty(productHelpParam.Sort))
            {
                switch (productHelpParam.Sort)
                {
                    case "priceAsc":
                        AddOrderBy(p => p.Price);
                        break;
                    case "priceDeac":
                        AddOrderByDescending(p => p.Price);
                        break;


                    default:
                        AddOrderBy(p => p.Name);
                        break;
                }
            }

        }
        public ProductWithIncludes(int Id) : base(x => x.Id == Id)
        {
            AddIncludes(a => a.productBrand);
            AddIncludes(a => a.productType);
            AddOrderBy(x => x.Name);
        }
    }
}
