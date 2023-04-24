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

        public Expression<Func<T, bool>> Filter { get; }

        public List<Expression<Func<T, object>>> Inculdes { get; } = new List<Expression<Func<T, object>>>();

        public Expression<Func<T, object>> OrderBy { get; private set; }

        public Expression<Func<T, object>> OrderByDescending { get; private set; }

        public int Take { get; private set; }

        public int Skip { get; private set; }

        public bool PagingIsEnable { get; private set; }

        protected void AddIncludes(Expression<Func<T, object>> IncludesExpression)
        {

            Inculdes.Add(IncludesExpression);
        }

        protected void AddOrderBy(Expression<Func<T, object>> orderByExpression)
        {
            OrderBy = orderByExpression;
        }

        protected void AddOrderByDescending(Expression<Func<T, object>> orderByDescendingExpression)
        {
            OrderByDescending = orderByDescendingExpression;

        }

        protected void ApplyPaging( int skip, int take)
        {
            Take = take;
            Skip = skip;
            PagingIsEnable = true;
        }
    }
}
