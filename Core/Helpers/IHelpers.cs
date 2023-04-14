using Core.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Helpers
{
    public interface IHelpers<T>
    {
         Expression<Func<T, bool>> Filter { get;  }
         List<Expression<Func<T, object>>> Inculdes { get; }
    }
}
