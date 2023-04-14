using Core.Entites;
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
     
            public ProductWithIncludes ()
            {
                AddIncludes(a => a.productBrand);
                AddIncludes(a => a.productType);
            }
        public ProductWithIncludes(int Id):base(x=>x.Id==Id)
        {
            AddIncludes(a => a.productBrand);
            AddIncludes(a => a.productType);
        }
    }
}
