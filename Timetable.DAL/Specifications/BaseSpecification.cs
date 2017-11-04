using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Timetable.DAL.Specifications
{
    public abstract class BaseSpecification<T> : ISpecification<T> where T : class
    {
        

        public BaseSpecification(Expression<Func<T, bool>> criteria)
        {
            Criteria = criteria;
        }

        public Expression<Func<T, bool>> Criteria { get; protected set; } 
        public List<Expression<Func<T, object>>> Includes { get; protected set; } = new List<Expression<Func<T, object>>>();
        public List<string> IncludeStrings { get; protected set; } = new List<string>();

        protected virtual void AddInclude(Expression<Func<T, object>> includeExpression)
        {
            Includes.Add(includeExpression);
            
        }

        protected virtual void AddInclude(string includeString)
        {
            IncludeStrings.Add(includeString);
        }
    }
}
