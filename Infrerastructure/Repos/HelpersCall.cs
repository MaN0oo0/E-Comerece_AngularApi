using Core.Entites;
using Core.Helpers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrerastructure.Repos
{
    public class HelpersCall<T> where T : BaseEntity
    {
        public static IQueryable<T> GetQuery(IQueryable<T> Query, IHelpers<T> help)
        {
            var query = Query;
            if (help.Filter != null)
            {
                query = query.Where(help.Filter);
            }
            if (help.OrderBy!=null)
            {
                query = query.OrderBy(help.OrderBy);
            }
            if (help.OrderByDescending!=null)
            {
                query = query.OrderByDescending(help.OrderByDescending);
            }
            if (help.PagingIsEnable)
            {
                query = query.Skip(help.Skip).Take(help.Take);
            }
            query = help.Inculdes.Aggregate(query, (current, include) => current.Include(include));
            return query; 
        }
    }
}
