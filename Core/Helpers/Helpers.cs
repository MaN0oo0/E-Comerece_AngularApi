using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Helpers
{
    public class Helpers<T> : IHelpers<T>
    {
        public Helpers(Expression<Func<T, bool>> filter)
        {
            Filter = filter;
 
        }
        public Helpers()
        {

        }

        public Expression<Func<T, bool>> Filter { get;  }

        public List<Expression<Func<T, object>>> Inculdes { get;  } = new List<Expression<Func<T, object>>>();



        protected void AddIncludes(Expression<Func<T, object>> IncludesExpression)
        {
           
            Inculdes.Add(IncludesExpression);
        }
    }
}
