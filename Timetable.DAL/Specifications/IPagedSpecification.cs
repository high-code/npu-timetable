using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Timetable.DAL.Specifications
{
    public interface IPagedSpecification<T> : ISpecification<T> where T : class
    {
        
        int PageSize { get; }
        int PageNumber { get; }
        Expression<Func<int>> Take { get; }
        Expression<Func<int>> Skip { get; }

    }
}
