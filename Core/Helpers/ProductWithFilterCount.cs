using Core.Entites;
using Core.Helpers.ProductHelperParam;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Helpers
{
    public class ProductWithFilterCount : Helpers<Product>
    {
        public ProductWithFilterCount(ProductHelpParam productHelpParam) : base(x =>



        (!productHelpParam.BrandId.HasValue || x.ProductBrandId == productHelpParam.BrandId)
        &&
        (!productHelpParam.TypeId.HasValue || x.ProductTypeId == productHelpParam.TypeId)


        )

        {

        }
    }
}
